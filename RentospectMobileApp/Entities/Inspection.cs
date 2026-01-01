using RentospectShared.CommonEnum;
using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("Inspection")]
    public class Inspection : AuditableEntity
    {
        [PrimaryKey]
        public Guid ID { get; set; }
        public string InspectionNumber { get; set; } = string.Empty;
        public int InspectionTypeID { get; set; }
        public InspectionCheckTypeEnum CheckType { get; set; }
        public string UserID { get; set; }
        public string CarID { get; set; }
        public DateTime InspectionDate { get; set; }
        public string DriverName { get; set; }
        public string DriverEmail { get; set; }
        public string AgreementNumber { get; set; }
        public bool IsPending { get; set; }
        public int CompanyID { get; set; }
        public string PlateNumber { get; set; }
        public InspactionStatusEnum Status { get; set; }
        public bool IsTermsAndConditionsAgreed { get; set; }
        public string SignaturePath { get; set; }
        public string? SignatureData { get; set; }
        public string? SignatureBase64 { get; set; }
    }
}
