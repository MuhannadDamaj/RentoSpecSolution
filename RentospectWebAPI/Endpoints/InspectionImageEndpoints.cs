using Microsoft.AspNetCore.Mvc;
using RentospectShared.DTOs;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class InspectionImageEndpoints
    {
        public static IEndpointRouteBuilder MapInspectionImageEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/inspections/{inspectionId:guid}/images", async (
                                                                                Guid inspectionId,
                                                                                IFormFile file,
                                                                                InspectionService inspectionService) =>
            {
                await inspectionService.SaveInspectionImageAsync(inspectionId, file);
                return Results.Ok(new { message = "Image uploaded" });
            });
            return app;
        }
    }
}
