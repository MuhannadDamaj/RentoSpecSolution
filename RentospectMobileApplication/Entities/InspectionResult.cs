using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApplication.Entities
{
    [Table("InspectionResult")]
    public class InspectionResult
    {
        [PrimaryKey]
        public Guid ID { get; set; }
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
        public string DetectedAngle { get; set; }
        public string? PlateNumber { get; internal set; }
    }
}
