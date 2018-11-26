namespace Contacts.DataLayer.Entity
{
    using System.ComponentModel.DataAnnotations;

    public partial class ContactRegister
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string ContactStatus { get; set; }
    }
}
