using RentospectWebAPI.Data.CommonEnum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentospectWebAPI.Data.Entities
{
    public class Inspection
    {
        public Guid ID { get; set; }
        public int InspectionTypeID { get; set; }
        public InspectionCheckTypeEnum CheckType { get; set; }
        public string UserID { get; set; }
        public string CarID { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public string DriverName { get; set; }
        public string AgreementNumber { get; set; }
        public bool IsPending { get; set; }
        public bool IsActive { get; set; } = true;
        // FK to Company
        [Required]
        public int CompanyID { get; set; }

        [ForeignKey("CompanyID")]
        public Company Company { get; set; }
    }
}
