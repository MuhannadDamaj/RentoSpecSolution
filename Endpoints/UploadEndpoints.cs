using RentospectShared.CommonEnum;
using RentospectWebAPI.Services;

namespace RentospectWebAPI.Endpoints
{
    public static class UploadEndpoints
    {
        public static IEndpointRouteBuilder MapUploadEndPoints(this IEndpointRouteBuilder app)
        {
            var uploadGroup = app.MapGroup("/api/upload").RequireAuthorization();

            uploadGroup.MapPost("/excel/{id}", async (int id,HttpRequest request, UploadService uploadService) =>
            {
                var file = request.Form.Files["file"];
                if (file == null)
                    return Results.BadRequest("No file uploaded");

                var result = await uploadService.UploadExcelAsync(file,id);
                return Results.Ok(result);
            })
            .RequireAuthorization(r => r.RequireRole(nameof(UserRoleEnum.Administrator)));

            return app;
        }
    }
}
