using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class InspectionTypeEndpoints
    {
        public static IEndpointRouteBuilder MapInspectionTypeEndPoints(this IEndpointRouteBuilder app)
        {
            var inspectionTypeGroup = app.MapGroup("/api/inspectiontypes").RequireAuthorization();
            inspectionTypeGroup.MapGet("", async (InspectionTypeService inspectionTypeService) =>
            Results.Ok(await inspectionTypeService.GetInspectionTypesAsync()));
            return app;
        }
    }
}
