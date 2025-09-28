using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;
using System.Reflection.Metadata.Ecma335;

namespace RentospectWebAPI.Endpoints
{
    public static class CurrencyEndpoints
    {
        public static IEndpointRouteBuilder MapCurrencyEndPoints(this IEndpointRouteBuilder app)
        {
            var currencyGroup = app.MapGroup("/api/currencies").RequireAuthorization();
            currencyGroup.MapGet("", async (CurrencyService currencyService) =>
            Results.Ok(await currencyService.GetCurrenciesAsync()));
            currencyGroup.MapPost("", async (CurrencyDto dto, CurrencyService currencyService) =>
            Results.Ok(await currencyService.SaveCurrencyAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
