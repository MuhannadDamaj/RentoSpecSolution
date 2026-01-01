using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("Branch")]
    public class Branch : AuditableEntity
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; } = true;
        public int CompanyID { get; set; }
    }
}
