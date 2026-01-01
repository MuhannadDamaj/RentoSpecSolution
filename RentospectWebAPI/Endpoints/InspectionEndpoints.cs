using Microsoft.AspNetCore.Mvc;
using RentospectShared.CommonEnum;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using RentospectWebAPI.Services;
using System.IO.Compression;

namespace RentospectWebAPI.Endpoints
{
    public static class InspectionEndpoints
    {
        public static IEndpointRouteBuilder MapInspectionEndPoints(this IEndpointRouteBuilder app)
        {
            var inspectionGroup = app.MapGroup("/api/inspections").RequireAuthorization();
            inspectionGroup.MapPost("upload", async ([FromBody] InspectionUploadDto dto, InspectionService inspectionService) =>
            {
                await inspectionService.SaveInspectionAsync(dto);
                return Results.Ok(new { message = "Inspection synced successfully" });
            });
            inspectionGroup.MapPost("{inspectionId:guid}/images/bulk", async (
                                                                                Guid inspectionId,
                                                                                HttpRequest request,
                                                                                InspectionService inspectionService,
                                                                                InspektAuthService authService,
                                                                                AIService aIService) =>
                                                                                {
                                                                                    try
                                                                                    {
                                                                                        var form = await request.ReadFormAsync();
                                                                                        var files = form.Files;

                                                                                        if (files.Count == 0)
                                                                                            return Results.BadRequest(new { success = false, message = "No photos received" });
                                                                                        List<InspectionImage> uploadedImages = new();

                                                                                        foreach (var file in files)
                                                                                        {
                                                                                            using var ms = new MemoryStream();
                                                                                            await file.CopyToAsync(ms);
                                                                                            var compressedBytes = ms.ToArray();
                                                                                            if (file.Headers.ContentEncoding == "gzip")
                                                                                                compressedBytes = Decompress(compressedBytes);
                                                                                            var image = await inspectionService.SaveInspectionImageBytesAsync(
                                                                                                inspectionId, file.FileName, compressedBytes);
                                                                                            uploadedImages.Add(image);
                                                                                        }

                                                                                        var imageResult = aIService.BuildAIRequestLists(uploadedImages);
                                                                                        var token = await authService.GetAuthTokenAsync();
                                                                                        string caseID = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
                                                                                        var aiResponse = await aIService.AnalyzeCarAsync(
                                                                                            token.Refresh_Token,
                                                                                            session: token.Session,
                                                                                            caseId: caseID,
                                                                                            urls: imageResult.urls,
                                                                                            originalIds: imageResult.originalIds
                                                                                        );
                                                                                        _ = inspectionService.UpdateInspectionAIInfo(inspectionId
                                                                                                                                    , token.Session
                                                                                                                                    , caseID);
                                                                                        return Results.Ok(new
                                                                                        {
                                                                                            success = true,
                                                                                            message = "Bulk images uploaded",
                                                                                            session = token.Session,
                                                                                            caseId = caseID
                                                                                        });
                                                                                    }
                                                                                    catch (Exception ex)
                                                                                    {
                                                                                        return Results.BadRequest(new
                                                                                        {
                                                                                            success = false,
                                                                                            message = ex.ToString()
                                                                                        });
                                                                                    }
                                                                                });
            return app;
        }
        public static byte[] Decompress(byte[] data)
        {
            using var input = new MemoryStream(data);
            using var gzip = new GZipStream(input, CompressionMode.Decompress);
            using var output = new MemoryStream();
            gzip.CopyTo(output);
            return output.ToArray();
        }
    }
}
