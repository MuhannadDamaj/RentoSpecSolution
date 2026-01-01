using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.AICallReadingEntities
{
    public class PreInspection
    {
        public string RecommendationStatus { get; set; }
        public string Message { get; set; }
        public List<DamagedPart> DamagedParts { get; set; }
    }
}
