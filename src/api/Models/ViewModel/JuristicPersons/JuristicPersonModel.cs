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

        [JsonProperty("businessName")]
        public string? BusinessName { get; set; }

        [JsonProperty("businessAcronym")]
        public string? BusinessAcronym { get; set; }

        [JsonProperty("taxDocument"), JsonRequiredValidate, JsonCnpj]
        public string? TaxDocument { get; set; }

        [JsonProperty("cnaeCode")]
        public int CnaeCode { get; set; }

        [JsonProperty("cnaeDescription")]
        public string? CnaeDescription { get; set; }



    }
}