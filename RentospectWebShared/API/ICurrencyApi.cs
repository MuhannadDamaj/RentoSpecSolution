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
    public interface ICurrencyApi
    {
        [Post("/api/currencies")]
        Task<CustomApiResponce> SaveCurrencyAsync(CurrencyDto currencyDto);
        [Get("/api/currencies")]
        Task<CurrencyDto[]> GetCurrenciesAsync();
    }
}
