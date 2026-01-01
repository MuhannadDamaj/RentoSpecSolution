using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class CarModelService
    {
        private readonly RentospectContext _context;
        public CarModelService(RentospectContext rentospectContext)
        {
            _context = rentospectContext;
        }
        public async Task<CustomApiResponce> SaveCarModelAsync(CarModelDto carModelDto)
        {
            if (carModelDto.ID == 0)
            {
                var CarModel = new CarModel()
                {
                    Description = carModelDto.Description,
                    IsActive = carModelDto.IsActive,
                    Name = carModelDto.Name,

                };
                _context.CarModels.Add(CarModel);
            }
            else
            {
                var dbCarModel = await _context.CarModels
                                  .FirstOrDefaultAsync(CarModel => CarModel.ID == CarModel.ID);
                if (dbCarModel == null)
                    return CustomApiResponce.Error("Car Make does not exist");
                dbCarModel.IsActive = carModelDto.IsActive;
                dbCarModel.Name = carModelDto.Name;
                dbCarModel.Description = carModelDto.Description;
                _context.CarModels.Update(dbCarModel);
            }
            await _context.SaveChangesAsync();
            return CustomApiResponce.Success();
        }
        public async Task<CarModelDto[]> GetCarModelsAsync() => await _context.CarModels
                                                                              .Where(cmp => cmp.IsActive)
                                                                              .AsNoTracking()
                                                                              .Select(c => new CarModelDto
                                                                              {
                                                                                  ID = c.ID,
                                                                                  Name = c.Name,
                                                                                  Description = c.Description,
                                                                                  IsActive = c.IsActive,
                                                                              }).ToArrayAsync();
    }
}
