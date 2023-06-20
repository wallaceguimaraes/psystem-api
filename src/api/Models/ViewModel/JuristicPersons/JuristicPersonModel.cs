using api.Validations;
using Newtonsoft.Json;

namespace api.Models.ViewModel.JuristicPersons
{
    public class JuristicPersonModel
    {
        [JsonProperty("fullName")]
        public string? FullName { get; set; }

        [JsonProperty("tradeName")]
        public string? TradeName { get; set; }

        [JsonProperty("businessTypeId")]
        public int BusinessTypeId { get; set; }

        [JsonProperty("taxDocument"), JsonRequiredValidate, JsonCnpj]
        public string? TaxDocument { get; set; }

        [JsonProperty("cnaeCode")]
        public int CnaeCode { get; set; }

    }
}