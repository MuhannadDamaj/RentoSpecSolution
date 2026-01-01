using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.AICallReadingEntities
{
    public class AdditionalFeatures
    {
        public object SizeOfDamage { get; set; }
        public List<object> HighProbabilityInternalDamages { get; set; }
        public string FastTrackFlag { get; set; }
        public string WindshieldDamageRegion { get; set; }
        public object HailDamage { get; set; }
        public object Blending_Data { get; set; }
    }
}
