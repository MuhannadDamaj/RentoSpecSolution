using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInspectionResult.AICallBack
{
    public class AdditionalFeature
    {
        public SizeOfDamage SizeOfDamage { get; set; }
        public List<object> HighProbabilityInternalDamages { get; set; }
        public string FastTrackFlag { get; set; }
        public string WindshieldDamageRegion { get; set; }
        public HailDamage HailDamage { get; set; }
        public BlendingData Blending_Data { get; set; }
    }
}
