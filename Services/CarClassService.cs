using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class CarClassService
    {
        private readonly RentospectContext _context;
        public CarClassService(RentospectContext rentospectContext)
        {
            _context = rentospectContext;
        }
        public async Task<CustomApiResponce> SaveCarClassAsync(CarClassDto carClassDto)
        {
            if (carClassDto.ID == 0)
            {
                var carClass = new CarClass()
                {
                    Name = carClassDto.Name,
                    CompanyID = carClassDto.CompanyID,
                    Description = carClassDto.Description,
                    IsActive = carClassDto.IsActive,
                };
                _context.CarClasses.Add(carClass);
            }
            else
            {
                var dbCarClass = await _context.CarClasses
                                  .FirstOrDefaultAsync(comp => comp.ID == carClassDto.ID);
                if (dbCarClass == null)
                    return CustomApiResponce.Error("Company does not exist");
                dbCarClass.CompanyID = carClassDto.CompanyID;
                dbCarClass.Description = carClassDto.Description;
                dbCarClass.IsActive = carClassDto.IsActive;
                dbCarClass.Name = carClassDto.Name;
                _context.CarClasses.Update(dbCarClass);
            }
            await _context.SaveChangesAsync();
            return CustomApiResponce.Success();
        }
        public async Task<CarClassDto[]> GetCarClassesAsync() => await _context.CarClasses
                                                                              .Where(carClass => carClass.IsActive)
                                                                              .AsNoTracking()
                                                                              .Select(c => new CarClassDto
                                                                              {
                                                                                  ID = c.ID,
                                                                                  Name = c.Name,
                                                                                  CompanyID = c.CompanyID,
                                                                                  Description = c.Description,
                                                                                  IsActive = c.IsActive,
                                                                              }).ToArrayAsync();
    }
}
