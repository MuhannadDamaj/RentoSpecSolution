using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class CarClassEndpoints
    {
        public static IEndpointRouteBuilder MapCarClassEndPoints(this IEndpointRouteBuilder app)
        {
            var carClassGroup = app.MapGroup("/api/carclasses").RequireAuthorization();
            carClassGroup.MapGet("", async (CarClassService carClassService) =>
            Results.Ok(await carClassService.GetCarClassesAsync()));
            carClassGroup.MapPost("", async (CarClassDto dto, CarClassService carClassService) =>
            Results.Ok(await carClassService.SaveCarClassAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
