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
    public interface ICarClassDamageApi
    {
        [Post("/api/carclassdamages")]
        Task<CustomApiResponce> SaveCarClassDamageAsync(CarClassDamageDto carClassDamageDto);
        [Get("/api/carclassdamages/bycarclass/{carClassID}")]
        Task<CarClassDamageDto[]> GetCarClassDamagesByCarClassIDAsync(int carClassID);
        [Get("/api/carclassdamages/bycompany/{companyId}")]
        Task<CarClassDamageDto[]> GetCarClassDamagesByCompanyIDAsync(int companyId);
    }
}
