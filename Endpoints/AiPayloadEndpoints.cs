using RentospectShared.AICallReadingEntities;
using RentospectWebAPI.Data.Entities.AiEntities;
using RentospectWebAPI.Data.Rentospect;
using RentospectWebAPI.Services;
using System;
using TestInspectionResult.AICallBack;
using Newtonsoft.Json;

namespace RentospectWebAPI.Endpoints
{
    public static class AiPayloadEndpoints
    {
        public static IEndpointRouteBuilder MapAiPayloadEndpoints(this IEndpointRouteBuilder app)
        {
            var aiGroup = app.MapGroup("/api/aipayload");

            aiGroup.MapPost("/callback", async (HttpRequest request, RentospectContext db) =>
            {
                using var reader = new StreamReader(request.Body);
                string body = await reader.ReadToEndAsync();

                AILog aILog = new AILog();
                aILog.ID = Guid.NewGuid();
                aILog.InspectionJson = body;
                db.aILogs.Add(aILog);
                await db.SaveChangesAsync();
                var inspectionCallback = JsonConvert.DeserializeObject<InspectionCallback>(body);
                if (inspectionCallback != null)
                {
                    Data.Entities.AiEntities.InspectionResult inspectionResult = new Data.Entities.AiEntities.InspectionResult();
                    inspectionResult.ID = Guid.NewGuid();
                    inspectionResult.ApiKey = inspectionCallback.ApiKey;
                    inspectionResult.Status = inspectionCallback.Status;
                    inspectionResult.CaseId = inspectionCallback.CaseId;
                    inspectionResult.InspectionId = inspectionCallback.InspectionId;
                    inspectionResult.Vendor = inspectionCallback.Vendor;
                    inspectionResult.Version = inspectionCallback.Version;
                    inspectionResult.UploadStatus = inspectionCallback.UploadStatus;
                    inspectionResult.VehicleType = inspectionCallback.VehicleType;
                    inspectionResult.AppFormData = inspectionCallback.AppFormData;
                    inspectionResult.GeoLocation = inspectionCallback.GeoLocation;
                    inspectionResult.DetectedAngle = string.Empty;
                    inspectionResult.LicensePlateReading = inspectionCallback?.VehicleReading?.LicensePlateReading;
                    List<Data.Entities.AiEntities.DamagedPart> damagedParts = new List<Data.Entities.AiEntities.DamagedPart>();
                    foreach (var damage in inspectionCallback.PreInspection.DamagedParts)
                    {
                        Data.Entities.AiEntities.DamagedPart damagedPart = new Data.Entities.AiEntities.DamagedPart();
                        damagedPart.ID = Guid.NewGuid();
                        damagedPart.PartName = damage.PartName;
                        damagedPart.ListOfDamages = damage.ListOfDamages;
                        damagedPart.DamageSeverityScore = damage.DamageSeverityScore;
                        damagedPart.LaborOperation = damage.LaborOperation;
                        damagedPart.ConfidenceScore = damage.ConfidenceScore;
                        damagedPart.PaintLaborUnits = damage.PaintLaborUnits;
                        damagedPart.RemovalRefitUnits = damage.RemovalRefitUnits;
                        damagedPart.LaborRepairUnits = damage.LaborRepairUnits;
                        damagedPart.InspectionResultID = inspectionResult.ID;
                        damagedParts.Add(damagedPart);
                    }
                    db.InspectionResults.Add(inspectionResult);
                    db.AddRange(damagedParts);
                    await db.SaveChangesAsync();
                }
                else
                {
                    aILog = new AILog();
                    aILog.ID = Guid.NewGuid();
                    aILog.InspectionJson = "Failed Desirialize";
                    db.aILogs.Add(aILog);
                    await db.SaveChangesAsync();
                }
                return Results.Ok(new { status = "received the payload" + body });
            });
            return app;
        }
    }
}
