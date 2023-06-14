using api.Extensions;
using api.Infrastructure.Security;
using api.Models.EntityModel.Users;
using api.Validations;
// using api.Validations;
// using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModel.Users
{
    public class UserUpdateModel
    {
        [Display(Name = "user.email"), JsonRequired, JsonEmail, JsonMaxLength(120)]
        public string? Email { get; set; }

        [Display(Name = "user.password"), JsonMinLength(8), JsonMaxLength(20)]
        public string? Password { get; set; }

        public User Map(User user)
        {
            user.Email = Email;

            if (!string.IsNullOrWhiteSpace(Password))
            {
                var salt = new Salt().ToString();
                user.Salt = salt;
                user.Password = Password.Encrypt(salt);
            }

            return user;
        }
    }
}
