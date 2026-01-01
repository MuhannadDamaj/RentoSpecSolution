using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInspectionResult.AICallBack
{
    public class InspectionCallback
    {
        public string Status { get; set; }
        public string CaseId { get; set; }
        public string InspectionId { get; set; }
        public string Vendor { get; set; }
        public string Version { get; set; }
        public string UploadStatus { get; set; }
        public string VehicleType { get; set; }
        public string AppFormData { get; set; }
        public string GeoLocation { get; set; }
        public VehicleReading VehicleReading { get; set; }
        public FraudDetection FraudDetection { get; set; }
        public PreInspection PreInspection { get; set; }
        public Claim Claim { get; set; }
        public AdditionalFeature AdditionalFeature { get; set; }
        public List<RelevantImage> RelevantImages { get; set; }
        public CustomSection CustomSection { get; set; }
        public TotalLoss TotalLoss { get; set; }
        public Document Document { get; set; }
        public string ApiKey { get; set; }
        public string ReportUrl { get; set; }
    }
}
