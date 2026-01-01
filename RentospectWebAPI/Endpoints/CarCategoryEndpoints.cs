using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class CarCategoryEndpoints
    {
        public static IEndpointRouteBuilder MapCarCategoryEndPoints(this IEndpointRouteBuilder app)
        {
            var carCategoryGroup = app.MapGroup("/api/carcategories").RequireAuthorization();
            carCategoryGroup.MapGet("", async (CarCategoryService carCategoryService) =>
            Results.Ok(await carCategoryService.GetCarCategoriesAsync()));
            carCategoryGroup.MapPost("", async (CarCategoryDto dto, CarCategoryService carCategoryService) =>
            Results.Ok(await carCategoryService.SaveCarCategoryAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
