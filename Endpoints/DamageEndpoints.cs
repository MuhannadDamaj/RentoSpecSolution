using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class DamageEndpoints
    {
        public static IEndpointRouteBuilder MapDamageEndPoints(this IEndpointRouteBuilder app)
        {
            var damageGroup = app.MapGroup("/api/damages").RequireAuthorization();
            damageGroup.MapGet("", async (DamageService damageService) =>
            Results.Ok(await damageService.GetDamagesAsync()));
            damageGroup.MapPost("", async (DamageDto dto, DamageService damageService) =>
            Results.Ok(await damageService.SaveDamageAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
