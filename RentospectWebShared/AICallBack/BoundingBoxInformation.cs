using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInspectionResult.AICallBack
{
    public class BoundingBoxInformation
    {
        public string PartComponent { get; set; }
        public string DamageType { get; set; }
        public List<string> DamageId { get; set; }
        public double DamageSeverityScore { get; set; }
        public double ConfidenceScore { get; set; }
        public int IsHailDamage { get; set; }
        public string HailSize { get; set; }
        public string NumberOfHailDamages { get; set; }
        public int PartOrientationUncertain { get; set; }
        public Coordinate Coordinate { get; set; }
    }
}
