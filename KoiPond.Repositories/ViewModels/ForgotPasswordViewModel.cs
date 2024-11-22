using System.ComponentModel.DataAnnotations;

namespace KoiPond.Repositories.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required, EmailAddress, Display(Name = "Register Email Address")]
        public string? Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
