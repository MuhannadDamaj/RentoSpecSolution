using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Entities.CustomEnitities
{
    public class DamageList
    {
        public Guid ID { get; set; }
        public string PartName { get; set; } = string.Empty;
        public string LaborOperation { get; set; } = string.Empty;
        public List<string> DamageDetails { get; set; } = new List<string>();
    }
}
