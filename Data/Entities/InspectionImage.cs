using RentospectWebAPI.Data.CommonEnum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentospectWebAPI.Data.Entities
{
    public class InspectionImage
    {
        [Key]
        public Guid ID { get; set; }
        public byte[] Image { get; set; }
        public string ImageURL { get; set; }
        [Required]
        public Guid InspectionID { get; set; }
        [ForeignKey("InspectionID")]
        public Inspection Inspection { get; set; }
        public bool IsActive { get; set; }
        public InspectionCheckTypeEnum CheckType { get; set; }
    }
}
