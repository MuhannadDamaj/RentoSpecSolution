using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class UploadImageEndpoints
    {
        public static IEndpointRouteBuilder MapUploadImageEndpoints(this IEndpointRouteBuilder app)
        {
            var uploadGroup = app.MapGroup("/api/upload").RequireAuthorization();

            uploadGroup.MapPost("/photo", async (IFormFile file, UploadImageService uploadService) =>
            {
                if (file == null || file.Length == 0)
                    return Results.BadRequest("No file uploaded");

                var path = await uploadService.SaveImageAsync(file);
                return Results.Ok(new { path });
            });

            return app;
        }
    }
}
