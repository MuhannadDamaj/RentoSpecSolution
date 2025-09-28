using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class CarMakeService
    {
        private readonly RentospectContext _context;
        public CarMakeService(RentospectContext rentospectContext)
        {
            _context = rentospectContext;
        }
        public async Task<CustomApiResponce> SaveCarMakeAsync(CarMakeDto carMakeDto)
        {
            if (carMakeDto.ID == 0)
            {
                var carMake = new CarMake()
                {
                    Description = carMakeDto.Description,
                    IsActive = carMakeDto.IsActive,
                    Name = carMakeDto.Name,

                };
                _context.CarMakes.Add(carMake);
            }
            else
            {
                var dbCarMake = await _context.CarMakes
                                  .FirstOrDefaultAsync(carMake => carMake.ID == carMake.ID);
                if (dbCarMake == null)
                    return CustomApiResponce.Error("Car Make does not exist");
                dbCarMake.IsActive = carMakeDto.IsActive;
                dbCarMake.Name = carMakeDto.Name;
                dbCarMake.Description = carMakeDto.Description;
                _context.CarMakes.Update(dbCarMake);
            }
            await _context.SaveChangesAsync();
            return CustomApiResponce.Success();
        }
        public async Task<CarMakeDto[]> GetCarMakesAsync() => await _context.CarMakes
                                                                              .Where(cmp => cmp.IsActive)
                                                                              .AsNoTracking()
                                                                              .Select(c => new CarMakeDto
                                                                              {
                                                                                  ID = c.ID,
                                                                                  Name = c.Name,
                                                                                  Description = c.Description,
                                                                                  IsActive = c.IsActive,
                                                                              }).ToArrayAsync();
    }
}
