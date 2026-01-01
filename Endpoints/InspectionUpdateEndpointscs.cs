using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class InspectionUpdateEndpointscs
    {
        public static IEndpointRouteBuilder MapInspectionUpdateEndPoints(this IEndpointRouteBuilder app)
        {
            var inspectionGroup = app.MapGroup("/api/inspectionupdate").RequireAuthorization();
            inspectionGroup.MapPost("update", async (InspectionUpdateDto dto, UpdateInspectionService service) =>
                Results.Ok(await service.UpdateInspectionAsync(dto)));
            return app;
        }
    }
}
