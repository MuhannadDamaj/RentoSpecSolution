using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class CarEndpoints
    {
        public static IEndpointRouteBuilder MapCarEndPoints(this IEndpointRouteBuilder app)
        {
            var carGroup = app.MapGroup("/api/cars").RequireAuthorization();
            carGroup.MapGet("", async (CarService carService) =>
            Results.Ok(await carService.GetCarsAsync()));
            carGroup.MapGet("{id:int}", async (int id,CarService carService) =>
            Results.Ok(await carService.GetCarsByCompanyIDAsync(id)));
            carGroup.MapPost("", async (CarDto dto, CarService carService) =>
            Results.Ok(await carService.SaveCarAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
