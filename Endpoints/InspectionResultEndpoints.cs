using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class InspectionResultEndpoints
    {
        public static IEndpointRouteBuilder MapInspectionResultEndPoints(this IEndpointRouteBuilder app)
        {
            var branchGroup = app.MapGroup("/api/inspectionresult").RequireAuthorization();
            branchGroup.MapGet("{inspectionId}", async (string inspectionId, InspectionResultService inspectionResultService) =>
            Results.Ok(await inspectionResultService.GetInspectionResultByInspectionID(inspectionId)));
            return app;
        }
    }
}
