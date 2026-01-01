using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class BulkUploadResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Session { get; set; }
        public string CaseId { get; set; }
    }
}
