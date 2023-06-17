using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModel.Users
{
    public class UserModel
    {
        [Display(Name = "email")]
        public string? Email { get; set; }

        [Display(Name = "password")]
        public string? Password { get; set; }

        [Display(Name = "roleId")]
        public long RoleId { get; set; }

    }
}