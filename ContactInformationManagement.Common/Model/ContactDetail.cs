using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactInformationManagement.Common.Model
{
    public class ContactDetail
    {
        public int ContactDetailId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public Status Status { get; set; } = Status.Active;

    }
}
