using api.Models.EntityModel.Companies;
using api.Validations;
using Newtonsoft.Json;

namespace api.Models.ViewModel.Companies
{
    public class CreateCompanyModel
    {
        [JsonProperty("tradeName"), JsonRequiredValidate]
        public string? TradeName { get; set; }

        [JsonProperty("fullName"), JsonRequiredValidate]
        public string? FullName { get; set; }

        [JsonProperty("taxDocument"), JsonRequiredValidate]
        public string? TaxDocument { get; set; }

        [JsonProperty("cnaeCode"), JsonRequiredValidate]
        public string? CnaeCode { get; set; }

        [JsonProperty("siglaNegocio"), JsonRequiredValidate]
        public string? BusinessAcronym { get; set; }

        [JsonProperty("negocio"), JsonRequiredValidate]
        public string? Business { get; set; }

        public Company Map()
        {
            return new Company
            {
                BusinessTypeName = Business,
                // TaxDocument = TaxDocument,
                // TradeName = TradeName,
                // FullName = FullName,
                // CnaeCode = CnaeCode,
                // BusinessTypeAcronym = BusinessAcronym,
                SystemImplementation = DateTime.Now
            };
        }
    }
}