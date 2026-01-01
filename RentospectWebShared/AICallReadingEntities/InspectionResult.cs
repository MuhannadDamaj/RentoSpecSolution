using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.AICallReadingEntities
{
    public class InspectionResult
    {
        public string ApiKey { get; set; }
        public string Status { get; set; }
        public string CaseId { get; set; }
        public string InspectionId { get; set; }
        public string Vendor { get; set; }
        public string Version { get; set; }
        public string UploadStatus { get; set; }
        public string VehicleType { get; set; }
        public string AppFormData { get; set; }
        public string GeoLocation { get; set; }
        public VehicleReadings VehicleReadings { get; set; }
        public FraudDetection FraudDetection { get; set; }
        public PreInspection PreInspection { get; set; }
        public string DetectedAngle { get; set; }
        public Claim Claim { get; set; }
        public AdditionalFeatures AdditionalFeatures { get; set; }
        public List<RelevantImage> RelevantImages { get; set; }
        public CustomSection CustomSection { get; set; }
        public TotalLoss TotalLoss { get; set; }
        public Document Document { get; set; }
    }
}
