using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class CarClassDamageService
    {
        private readonly RentospectContext _context;
        public CarClassDamageService(RentospectContext rentospectContext)
        {
            _context = rentospectContext;
        }
        public async Task<CustomApiResponce> SaveCarClassDamageAsync(CarClassDamageDto carClassDamageDto)
        {
            var dbCarClassDamages = await _context.CarClassDamages
                                  .FirstOrDefaultAsync(carClassDamage => carClassDamage.ID == carClassDamageDto.ID);

            if (dbCarClassDamages == null)
            {
                var carClassDamage = new CarClassDamage()
                {
                    CarClassID = carClassDamageDto.CarClassID,
                    DamageID = carClassDamageDto.DamageID,
                    IsActive = carClassDamageDto.IsActive,
                    Price = carClassDamageDto.Price,
                };
                _context.CarClassDamages.Add(carClassDamage);
            }
            else
            {
                dbCarClassDamages.IsActive = carClassDamageDto.IsActive;
                dbCarClassDamages.Price = carClassDamageDto.Price;
                dbCarClassDamages.CarClassID = carClassDamageDto.CarClassID;
                dbCarClassDamages.DamageID = carClassDamageDto.DamageID;
                _context.CarClassDamages.Update(dbCarClassDamages);
            }
            await _context.SaveChangesAsync();
            return CustomApiResponce.Success();
        }
        public async Task<CarClassDamageDto[]> GetCarClassDamagesByCarClassIDAsync(int id) => await _context.CarClassDamages
                                                                                                   .Where(ccDamage => ccDamage.IsActive
                                                                                                                 && ccDamage.CarClassID == id)
                                                                                                   .AsNoTracking()
                                                                                                   .Select(c => new CarClassDamageDto
                                                                                                   {
                                                                                                       ID = c.ID,
                                                                                                       IsActive = c.IsActive,
                                                                                                       CarClassID = c.CarClassID,
                                                                                                       DamageID = c.DamageID,
                                                                                                       Price = c.Price
                                                                                                   }).ToArrayAsync();
    }
}
