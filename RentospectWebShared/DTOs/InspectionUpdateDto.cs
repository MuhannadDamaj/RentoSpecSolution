using RentospectShared.CommonEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class InspectionUpdateDto
    {
        public Guid ID { get; set; }
        public bool IsTermsAndConditionsAgreed { get; set; }
        public int Status { get; set; }
        public string? SignaturePath { get; set; }
        public string? SignatureData { get; set; }
        public string? SignatureBase64 { get; set; }
    }
}
