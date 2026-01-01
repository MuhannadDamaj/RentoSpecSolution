using RentospectShared.CommonEnum;
using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("InspectionSignature")]
    public class InspectionSignature
    {
        [PrimaryKey]
        public Guid ID { get; set; }
        public byte[] Signature { get; set; }
        public string SignatureURL { get; set; }
        public Guid InspectionID { get; set; }
        public InspectionCheckTypeEnum CheckType { get; set; }
    }
}
