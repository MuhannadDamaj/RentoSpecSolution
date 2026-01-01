using CommunityToolkit.Maui.Core;
using RentospectShared.AICallReadingEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Entities.CustomEnitities
{
    public class InspectionHolderDTO
    {
        public Inspection? Inspection { get; set; }
        public List<ImageSource> InspectionPhotos { get; set; } = new List<ImageSource>();
        public List<DamagedPart> DamagedParts { get; internal set; }
        public ImageSource? SignatureImage { get; set; }
        public byte[]? SignatureBytes { get; set; }
        public ObservableCollection<IDrawingLine> SignatureLines { get; set; }
    }
}
