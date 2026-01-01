using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class UploadResultDto
    {
        public int TotalRows { get; set; }
        public int SuccessRows { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
