using System.ComponentModel.DataAnnotations;
using api.Models.EntityModel.Companies;
using api.Validations;

namespace api.Models.ViewModel.Employee
{
    public class SignupCompanyViewModel
    {
        [Display(Name = "siglaTipoNegocio"), JsonRequired]
        public string? BusinessTypeAcronym { get; set; }

        [Display(Name = "tipoNegocio"), JsonRequired]
        public string? BusinessTypeName { get; set; }

        [Display(Name = "tradeName"), JsonRequired]
        public string? TradeName { get; set; }

        [Display(Name = "fullName"), JsonRequired]
        public string? FullName { get; set; }

        [Display(Name = "taxDocument"), JsonRequired, JsonCnpj]
        public string? TaxDocument { get; set; }

        [Display(Name = "cnaeCode"), JsonRequired]
        public string? CnaeCode { get; set; }

        [Display(Name = "systemImplementation")]
        public DateTime SystemImplementation { get; set; } = DateTime.Now;

        public Company Map()
        {
            return new Company
            {
                BusinessTypeName = BusinessTypeName,
                TaxDocument = TaxDocument,
                TradeName = TradeName,
                FullName = FullName,
                CnaeCode = CnaeCode,
                BusinessTypeAcronym = BusinessTypeAcronym,
                SystemImplementation = SystemImplementation
            };
        }

    }
}