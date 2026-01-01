using RentospectWebAPI.Data.Entities.AiEntities;
using RentospectWebAPI.Data.Rentospect;

namespace RentospectWebAPI.Services
{
    public class AiPayloadService
    {
        public AiPayloadService(RentospectContext rentospectContext) 
        {
            RentospectContext = rentospectContext;
        }

        public RentospectContext RentospectContext { get; }

        public async Task<bool> SavePayloadAsync(RentospectShared.AICallReadingEntities.InspectionResult dto)
        {
            try
            {
                InspectionResult result = new InspectionResult();
                result.ID = Guid.NewGuid() ;
                result.ApiKey = dto.ApiKey;
                result.AppFormData = dto.AppFormData;
                result.CaseId = dto.CaseId;
                result.DetectedAngle = dto.DetectedAngle;
                result.GeoLocation = dto.GeoLocation;
                result.InspectionId = dto.InspectionId;
                result.Status = dto.Status;
                result.UploadStatus = dto.UploadStatus;
                result.VehicleType = dto.VehicleType;
                result.Version = dto.Version;
                result.Vendor = dto.Vendor;

                RentospectContext.InspectionResults.Add(result);
                await RentospectContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to save inspection: {ex.Message}");
                return false;
            }
            Console.WriteLine($"First inspection saved");
            return true;
        }
    }
}
