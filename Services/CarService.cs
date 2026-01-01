using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class CarService
    {
        private readonly RentospectContext _context;
        public CarService(RentospectContext rentospectContext)
        {
            _context = rentospectContext;
        }
        public async Task<CustomApiResponce> SaveCarAsync(CarDto carDto)
        {
            if (carDto.ID == 0)
            {
                var car = new Car()
                {
                    CarClassId = carDto.CarClassId,
                    Color = carDto.Color,
                    IsActive = carDto.IsActive,
                    MVA_Number = carDto.MVA_Number,
                    PlateNumber = carDto.PlateNumber,
                    Year = carDto.Year,
                    CarMake = carDto.CarMake,
                    CarModel = carDto.CarModel
                };
                _context.Cars.Add(car);
            }
            else
            {
                var dbCar = await _context.Cars
                                  .FirstOrDefaultAsync(car => car.ID == carDto.ID);
                if (dbCar == null)
                    return CustomApiResponce.Error("Car does not exist");
                dbCar.IsActive = carDto.IsActive;
                dbCar.MVA_Number = carDto.MVA_Number;
                dbCar.PlateNumber = carDto.PlateNumber;
                dbCar.Year = carDto.Year;
                dbCar.Color = carDto.Color;

                _context.Cars.Update(dbCar);
            }
            await _context.SaveChangesAsync();
            return CustomApiResponce.Success();
        }
        public async Task<CarDto[]> GetCarsAsync() => await _context.Cars
                                                                    .Where(car => car.IsActive)
                                                                    .AsNoTracking()
                                                                    .Select(c => new CarDto
                                                                    {
                                                                        ID = c.ID,
                                                                        CarClassId = c.CarClassId,
                                                                        Year = c.Year,
                                                                        Color = c.Color,
                                                                        MVA_Number = c.MVA_Number,
                                                                        PlateNumber = c.PlateNumber,
                                                                        IsActive = c.IsActive,
                                                                        CarMake = c.CarMake,
                                                                        CarModel = c.CarModel
                                                                    }).ToArrayAsync();
        public async Task<CarDto[]> GetCarsByCompanyIDAsync(int companyId) => await _context.Cars
                                                                                            .Where(car => car.IsActive && car.CarClass.CompanyID == companyId)
                                                                                            .AsNoTracking()
                                                                                            .Select(c => new CarDto
                                                                                            {
                                                                                                ID = c.ID,
                                                                                                CarClassId = c.CarClassId,
                                                                                                Year = c.Year,
                                                                                                Color = c.Color,
                                                                                                MVA_Number = c.MVA_Number,
                                                                                                PlateNumber = c.PlateNumber,
                                                                                                IsActive = c.IsActive,
                                                                                                CarMake = c.CarMake,
                                                                                                CarModel = c.CarModel,
                                                                                                CreatedAt = c.CreatedAt,
                                                                                                CreatedBy = c.CreatedBy,
                                                                                                UpdatedAt = c.UpdatedAt,
                                                                                                UpdatedBy = c.UpdatedBy,
                                                                                            }).ToArrayAsync();
    }
}
