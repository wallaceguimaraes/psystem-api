using api.Validations;
using Newtonsoft.Json;

namespace api.Models.ViewModel
{
    public class CredentialsViewModel
    {
        [JsonProperty("email"), JsonRequiredValidate]
        public string? Email { get; set; }

        [JsonProperty("password"), JsonRequiredValidate]
        public string? Password { get; set; }

    }
}