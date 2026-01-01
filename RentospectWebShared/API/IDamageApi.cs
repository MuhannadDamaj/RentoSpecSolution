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
    public interface IDamageApi
    {
        [Post("/api/damages")]
        Task<CustomApiResponce> SaveDamageAsync(DamageDto damageDto);
        [Get("/api/damages")]
        Task<DamageDto[]> GetDamagesAsync();
    }
}
