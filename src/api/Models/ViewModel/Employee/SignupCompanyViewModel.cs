#pragma warning disable CS8618


using System.ComponentModel.DataAnnotations;
using api.Models.EntityModel.Companies;

namespace api.Models.ViewModel.Employee
{
    public class SignupCompanyViewModel
    {
        [Display(Name = "tradeName")]
        public string? TradeName { get; set; }

        [Display(Name = "fullName")]
        public string? FullName { get; set; }

        // [Display(Name = "taxDocument"), JsonRequired, JsonCnpj]
        // public string? TaxDocument { get; set; }

        // [Display(Name = "cnaeCode"), JsonRequired]
        // public string? CnaeCode { get; set; }

        // [Display(Name = "siglaNegocio")]
        // public string BusinessAcronym { get; set; }

        // [Display(Name = "negocio")]
        public string Business { get; set; }

        public Company Map()
        {
            return new Company
            {
                BusinessTypeName = "Business",
                TaxDocument = "TaxDocument",
                TradeName = "TradeName",
                FullName = "FullName",
                CnaeCode = "CnaeCode",
                BusinessTypeAcronym = "BusinessAcronym",
                SystemImplementation = DateTime.Now
            };
        }

    }
}

