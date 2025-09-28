using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class CarClassDamageEndpoints
    {
        public static IEndpointRouteBuilder MapCarClassDamageEndPoints(this IEndpointRouteBuilder app)
        {
            var carClassDamageGroup = app.MapGroup("/api/carclassdamages").RequireAuthorization();
            carClassDamageGroup.MapGet("{id:int}", async (int id, CarClassDamageService carClassDamageService) =>
            Results.Ok(await carClassDamageService.GetCarClassDamagesByCarClassIDAsync(id)));
            carClassDamageGroup.MapPost("", async (CarClassDamageDto dto, CarClassDamageService carClassDamageService) =>
            Results.Ok(await carClassDamageService.SaveCarClassDamageAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
