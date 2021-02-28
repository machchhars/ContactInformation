

using System.ComponentModel.DataAnnotations;

namespace ContactInformationManagement.Common.DTO
{
    public class ContactDetailDTO
    {
        public int? ContactDetailId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
         ErrorMessage = "please enter valid email address eg: abc@domain.com")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(91){0,1}[9876]{1}[0-9]{9}$",
         ErrorMessage = "please enter valid mobile number eg format: 919876543210 or 9876543210")]
        public long PhoneNumber { get; set; }
        public string Status { get; set; }
    }
}