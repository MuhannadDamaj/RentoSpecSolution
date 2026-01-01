using Refit;
using RentospectShared.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.API
{
    [Headers("Authorization: Bearer ")]
    public interface ICarClassApi
    {
        [Post("/api/carclasses")]
        Task<CustomApiResponce> SaveCarClassesAsync(CarClassDto carClassDto);
        [Get("/api/carclasses")]
        Task<CarClassDto[]> GetCarClassesAsync();
        [Get("/api/carclasses/{companyId}")]
        Task<CarClassDto[]> GetCarClassesByCompanyIDAsync(int companyId);
    }
}
