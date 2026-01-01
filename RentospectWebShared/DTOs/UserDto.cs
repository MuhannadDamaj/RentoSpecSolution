using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectShared.DTOs
{
    public class UserDto : AuditableEntity, IValidatableObject
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FullName { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        // Remove [Required] — will validate conditionally
        public string Password { get; set; }

        // Remove [Required] — will validate conditionally
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public int BranchID { get; set; }
        public bool ForcePasswordChange { get; set; }

        // ⭐ CONDITIONAL VALIDATION LOGIC

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ID == 0 || ForcePasswordChange)
            {
                if (string.IsNullOrWhiteSpace(Password))
                    yield return new ValidationResult("Password is required.", new[] { nameof(Password) });

                if (string.IsNullOrWhiteSpace(ConfirmPassword))
                    yield return new ValidationResult("Confirm Password is required.", new[] { nameof(ConfirmPassword) });

                // Password match validation (same as Add Mode)
                if (!string.Equals(Password, ConfirmPassword))
                    yield return new ValidationResult("Passwords do not match.", new[] { nameof(ConfirmPassword) });
            }
        }
    }
}
