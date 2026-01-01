using RentospectShared.CommonEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class InspectionUploadDto
    {
        public Guid ID { get; set; }
        public string InspectionNumber { get; set; } = string.Empty;
        public int InspectionTypeID { get; set; }
        public int CheckType { get; set; }
        public int UserID { get; set; }
        public int CarID { get; set; }
        public DateTime InspectionDate { get; set; }
        public string DriverName { get; set; }
        public string DriverEmail { get; set; }
        public string AgreementNumber { get; set; }
        public int CompanyID { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public int Status { get; set; }
        public bool IsTermsAndConditionsAgreed { get; set; }
        public string? SignatureBase64 { get; set; }
    }
}
