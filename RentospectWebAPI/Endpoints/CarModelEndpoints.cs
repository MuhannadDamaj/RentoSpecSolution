using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class CarModelEndpoints
    {
        public static IEndpointRouteBuilder MapCarModelEndPoints(this IEndpointRouteBuilder app)
        {
            var carModelGroup = app.MapGroup("/api/carmodels").RequireAuthorization();
            carModelGroup.MapGet("", async (CarModelService carModelService) =>
            Results.Ok(await carModelService.GetCarModelsAsync()));
            carModelGroup.MapPost("", async (CarModelDto dto, CarModelService carModelService) =>
            Results.Ok(await carModelService.SaveCarModelAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
