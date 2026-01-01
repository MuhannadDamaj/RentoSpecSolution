using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class MasterSyncEndpoints
    {
        public static IEndpointRouteBuilder MapMasterSyncEndPoints(this IEndpointRouteBuilder app)
        {
            var masterGroup = app.MapGroup("/api/master").RequireAuthorization();
            masterGroup.MapGet("sync", async (int userId, int companyId, MasterSyncService masterSyncService) =>
                Results.Ok(await masterSyncService.GetMasterSyncAsync(userId, companyId)));
            return app;
        }
    }
}
