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
    public interface ICarApi
    {
        [Post("/api/cars")]
        Task<CustomApiResponce> SaveCarAsync(CarDto carDto);
        [Get("/api/cars")]
        Task<CarDto[]> GetCarsAsync();
        [Get("/api/cars/{companyId}")]
        Task<CarDto[]> GetCarsByCompanyIDAsync(int companyId);
    }
}
