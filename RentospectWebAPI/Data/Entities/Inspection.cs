using RentospectShared.CommonEnum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentospectWebAPI.Data.Entities
{
    public class Inspection
    {
        public Guid ID { get; set; }
        public string InspectionNumber { get; set; } = string.Empty;
        public string CaseID { get; set; } = string.Empty;
        public int InspectionTypeID { get; set; }
        public InspectionCheckTypeEnum CheckType { get; set; }
        public int UserID { get; set; }
        public int CarID { get; set; }
        public DateTime InspectionDate { get; set; }
        public string DriverName { get; set; }
        public string DriverEmail { get; set; }
        public string AgreementNumber { get; set; }
        public bool IsPending { get; set; }
        public string? PlateNumber { get; set; }
        public InspactionStatusEnum Status { get; set; }
        public bool IsTermsAndConditionsAgreed { get; set; }
        public string? SignatureBase64 { get; set; }
        public bool IsActive { get; set; } = true;
        // FK to Company
        [Required]
        public int CompanyID { get; set; }
        [NotMapped]
        public Company Company { get; set; }
        [NotMapped]
        public User User { get; set; }
        [NotMapped]
        public Car Car { get; set; }
    }
}
