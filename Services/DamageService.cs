using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;
using static System.Net.Mime.MediaTypeNames;

namespace RentospectWebAPI.Services
{
    public class DamageService
    {
        private readonly RentospectContext _context;
        public DamageService(RentospectContext rentospectContext)
        {
            _context = rentospectContext;
        }
        public async Task<CustomApiResponce> SaveDamageAsync(DamageDto damageDto)
        {
            if (damageDto.ID == 0)
            {
                var damage = new Damage()
                {
                    ShortDescription = damageDto.ShortDescription,
                    IsActive = damageDto.IsActive,
                    ExampleOnePhoto = damageDto.ExampleOnePhoto,
                    ExampleTwoPhoto = damageDto.ExampleTwoPhoto,
                };
                _context.Damages.Add(damage);
            }
            else
            {
                try
                {
                    var dbDamage = await _context.Damages
                                  .FirstOrDefaultAsync(damage => damage.ID == damage.ID);
                    if (dbDamage == null)
                        return CustomApiResponce.Error("Damage Make does not exist");
                    dbDamage.ShortDescription = damageDto.ShortDescription;
                    dbDamage.IsActive = damageDto.IsActive;
                    dbDamage.ExampleOnePhoto = damageDto.ExampleOnePhoto;
                    dbDamage.ExampleTwoPhoto = damageDto.ExampleTwoPhoto;
                    _context.Damages.Update(dbDamage);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex) { throw ex; }
            return CustomApiResponce.Success();
        }
        public async Task<DamageDto[]> GetDamagesAsync() => await _context.Damages
                                                                              .Where(dm => dm.IsActive)
                                                                              .AsNoTracking()
                                                                              .Select(c => new DamageDto
                                                                              {
                                                                                  ExampleOnePhoto = c.ExampleOnePhoto,
                                                                                  ExampleTwoPhoto = c.ExampleTwoPhoto,
                                                                                  IsActive = c.IsActive,
                                                                                  ID = c.ID,
                                                                                  ShortDescription = c.ShortDescription,
                                                                                  CreatedAt = c.CreatedAt,
                                                                                  CreatedBy = c.CreatedBy,
                                                                                  UpdatedAt = c.UpdatedAt,
                                                                                  UpdatedBy = c.UpdatedBy,
                                                                              }).ToArrayAsync();
    }
}
