using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndPoints(this IEndpointRouteBuilder app)
        {
            var userGroup = app.MapGroup("/api/users").RequireAuthorization();
            userGroup.MapGet("", async (UserService userService) =>
            Results.Ok(await userService.GetUsersAsync()));
            userGroup.MapGet("{id:int}", async (int id, UserService userService) =>
            Results.Ok(await userService.GetUserByIDAsync(id)));
            userGroup.MapPost("", async (UserDto dto, UserService userService) =>
            Results.Ok(await userService.SaveUserAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
