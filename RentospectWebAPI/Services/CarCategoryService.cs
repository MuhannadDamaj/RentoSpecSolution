using Microsoft.EntityFrameworkCore;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class CarCategoryService
    {
        private readonly RentospectContext _context;
        public CarCategoryService(RentospectContext rentospectContext)
        {
            _context = rentospectContext;
        }
        public async Task<CustomApiResponce> SaveCarCategoryAsync(CarCategoryDto carCategoryDto)
        {
            if (carCategoryDto.ID == 0)
            {
                var carCategory = new CarCategory()
                {
                    Description = carCategoryDto.Description,
                    IsActive = carCategoryDto.IsActive,
                    Name = carCategoryDto.Name,

                };
                _context.CarCategories.Add(carCategory);
            }
            else
            {
                var dbCarCategory = await _context.CarCategories
                                  .FirstOrDefaultAsync(CarCategory => CarCategory.ID == CarCategory.ID);
                if (dbCarCategory == null)
                    return CustomApiResponce.Error("Car Make does not exist");
                dbCarCategory.IsActive = carCategoryDto.IsActive;
                dbCarCategory.Name = carCategoryDto.Name;
                dbCarCategory.Description = carCategoryDto.Description;
                _context.CarCategories.Update(dbCarCategory);
            }
            await _context.SaveChangesAsync();
            return CustomApiResponce.Success();
        }
        public async Task<CarCategoryDto[]> GetCarCategoriesAsync() => await _context.CarCategories
                                                                              .Where(cmp => cmp.IsActive)
                                                                              .AsNoTracking()
                                                                              .Select(c => new CarCategoryDto
                                                                              {
                                                                                  ID = c.ID,
                                                                                  Name = c.Name,
                                                                                  Description = c.Description,
                                                                                  IsActive = c.IsActive,
                                                                              }).ToArrayAsync();
    }
}
