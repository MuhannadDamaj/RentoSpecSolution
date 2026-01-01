using RentospectShared.CommonEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class InspectionDto
    {
        public Guid ID { get; set; }
        public string InspectionNumber { get; set; } = string.Empty;
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
        public int CompanyID { get; set; }
        public string? CarPlateNumber { get; set; }
        public int Year { get; set; }
        public string? CarColor { get; set; }
        public string? CarMVA_Number { get; set; }
        public string? CarMake { get; set; }
        public string? CarModel { get; set; }
        public string? UserFullName { get; set; }
        public string? CompanyName { get; set; }
        public string? CaseID { get; set; }
    }
}
