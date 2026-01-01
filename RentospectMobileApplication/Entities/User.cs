using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("User")]
    public class User : AuditableEntity
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;
        public int CompanyID { get; set; }
        public int BranchID { get; set; }
    }
}
