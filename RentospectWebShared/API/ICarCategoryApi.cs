using Refit;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    [Headers("Authorization: Bearer ")]
    public interface ICarCategoryApi
    {
        [Post("/api/carcategories")]
        Task<CustomApiResponce> SaveCarCategoryAsync(CarCategoryDto carCategoryDto);
        [Get("/api/carcategories")]
        Task<CarCategoryDto[]> GetCarCategoriesAsync();
    }
}
