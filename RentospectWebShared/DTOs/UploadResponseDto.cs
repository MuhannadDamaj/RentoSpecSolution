using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class UploadResponseDto
    {
        public string Message { get; set; }
        public List<string> ImageUrls { get; set; } = new();
        public bool Success { get; set; }
    }
}
