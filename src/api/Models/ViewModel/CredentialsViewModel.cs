using System.ComponentModel.DataAnnotations;
using api.Validations;

namespace api.Models.ViewModel
{
    public class CredentialsViewModel
    {
        [Display(Name = "email"), JsonRequired]
        public string? Email { get; set; }

        [Display(Name = "password"), JsonRequired]
        public string? Password { get; set; }

    }
}