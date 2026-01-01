using System.ComponentModel.DataAnnotations;
using SQLite;

namespace RentospectMobileApp.Entities
{
    [Table("Damage")]
    public class Damage : AuditableEntity
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string ShortDescription { get; set; }
        public string ExampleOnePhoto { get; set; }
        public string ExampleTwoPhoto { get; set; }
    }
}
