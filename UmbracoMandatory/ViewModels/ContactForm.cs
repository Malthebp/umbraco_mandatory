using System.ComponentModel.DataAnnotations;

namespace UmbracoMandatory.ViewModels
{
    public class ContactForm
    {
        [Required]
        [EmailAddress(ErrorMessage = "This is not a valid e-mail adddress.")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}