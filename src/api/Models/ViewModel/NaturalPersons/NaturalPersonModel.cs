using api.Validations;
using Newtonsoft.Json;

namespace api.Models.ViewModel.NaturalPersons
{
    public class NaturalPersonModel
    {

        [JsonProperty("fullName")]
        public string? FullName { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("gender")]
        public string? Gender { get; set; }

        [JsonProperty("taxDocument"), JsonRequiredValidate, JsonCpf]
        public string? TaxDocument { get; set; }
    }
}