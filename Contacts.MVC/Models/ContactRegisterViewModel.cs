using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Contacts.WebApi.Models
{
    public class ContactRegisterViewModel
    {

        [DisplayName("Contact Id")]
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
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [DisplayName("Status")]
        public string ContactStatus { get; set; }

        public IEnumerable<SelectListItem> ListStatus { get; set; }
    }

}
