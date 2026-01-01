using System.ComponentModel.DataAnnotations;

namespace RentospectShared.DTOs
{
    public class LoginDto
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string UserName {  get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsFromMobile { get; set; } = false;
    }
}
