using RentospectShared.CommonEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Entities.CustomEnitities
{
    public class EnumItem
    {
        public string Name { get; set; }
        public InspectionCheckTypeEnum? Value { get; set; } 
    }
}
