using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class AIRequest
    {
        public string session { get; set; }
        public string type { get; set; } = "urls"; // always "urls" in your example
        public string[] urls { get; set; }
        public string[] original_Id { get; set; }
        public string case_id { get; set; }
        public string callback_url { get; set; }
    }
}
