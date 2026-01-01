using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.AICallReadingEntities
{
    public class RelevantImage
    {
        public string ImageId { get; set; }
        public string OriginalImageId { get; set; }
        public string ImageUrl { get; set; }
        public string OriginalImageURL { get; set; }
        public string RequestImageUrl { get; set; }
        public double QualityScore { get; set; }
        public double BlurScore { get; set; }
        public double LumaScore { get; set; }
        public double ZoomScore { get; set; }
        public string ImageTag { get; set; }
        public string PhotoType { get; set; }
        public List<BoundingBoxInformation> BoundingBoxInformation { get; set; }
        public string GeoLocation { get; set; }
        public string TimeStamp { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
    }
}
