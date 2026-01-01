using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class PortalInspectionEndpoints
    {
        public static IEndpointRouteBuilder MapPortalInspectionEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/portalinspections").RequireAuthorization();
            // GET: /api/portalinspections/{companyId}
            group.MapGet("{companyId:int}", async (int companyId, PortalInspectionService service) =>
                Results.Ok(await service.GetInspectionsByCompanyIdAsync(companyId)));
           
            return app;
        }
    }
}
