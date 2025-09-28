using RentospectWebAPI.Data.CommonEnum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentospectWebAPI.Data.Entities
{
    public class InspectionSignature
    {
        [Key]
        public Guid ID { get; set; }
        public byte[] Signature { get; set; }
        public string SignatureURL { get; set; }
        [Required]
        public Guid InspectionID { get; set; }
        [ForeignKey("InspectionID")]
        public Inspection Inspection { get; set; }
        public bool IsActive { get; set; }
        public InspectionCheckTypeEnum CheckType { get; set; }
    }
}
