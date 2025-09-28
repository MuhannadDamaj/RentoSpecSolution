using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class BranchEndpoints
    {
        public static IEndpointRouteBuilder MapBranchEndPoints(this IEndpointRouteBuilder app)
        {
            var branchGroup = app.MapGroup("/api/branches").RequireAuthorization();
            branchGroup.MapGet("", async (BranchService branchService) =>
            Results.Ok(await branchService.GetBranchesAsync()));
            branchGroup.MapPost("", async (BranchDto dto, BranchService branchService) =>
            Results.Ok(await branchService.SaveBranchAsync(dto)))
                .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));
            return app;
        }
    }
}
