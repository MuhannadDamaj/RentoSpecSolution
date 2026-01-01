using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class CarMakeEndpoints
    {
        public static IEndpointRouteBuilder MapCarMakeEndPoints(this IEndpointRouteBuilder app)
        {
            var carMakeGroup = app.MapGroup("/api/carmakes").RequireAuthorization();
            carMakeGroup.MapGet("", async (CarMakeService carMakeService) =>
            Results.Ok(await carMakeService.GetCarMakesAsync()));
            carMakeGroup.MapPost("", async (CarMakeDto dto, CarMakeService carMakeService) =>
            Results.Ok(await carMakeService.SaveCarMakeAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
