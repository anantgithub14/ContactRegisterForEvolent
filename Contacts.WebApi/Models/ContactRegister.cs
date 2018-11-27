using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contacts.WebApi.Models
{
    public class ContactRegister
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Wrong email format")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DisplayName("Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string ContactStatus { get; set; }
    }

}
