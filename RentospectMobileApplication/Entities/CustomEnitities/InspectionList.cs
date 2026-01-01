using RentospectMobileApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApplication.Entities.CustomEnitities
{
    public class InspectionList : Inspection
    {
        public List<DamagedPart> DamagedParts { get; set; } = new List<DamagedPart>();
    }
}
