using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class InspectionImageUploadDto
    {
        public string FileName { get; set; }
        public string LocalFilePath { get; set; } // Path in mobile storage
        public int OrderIndex { get; set; }
    }
}
