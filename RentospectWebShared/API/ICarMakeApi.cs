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
    public interface ICarMakeApi
    {
        [Post("/api/carmakes")]
        Task<CustomApiResponce> SaveCarMakeAsync(CarMakeDto carMakeDto);
        [Get("/api/carmakes")]
        Task<CarMakeDto[]> GetCarMakesAsync();
    }
}
