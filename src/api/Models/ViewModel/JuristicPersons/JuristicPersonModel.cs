using System.ComponentModel.DataAnnotations;
using api.Validations;

namespace api.Models.ViewModel.JuristicPersons
{
    public class JuristicPersonModel
    {
        [Display(Name = "fullName")]
        public string? FullName { get; set; }

        [Display(Name = "tradeName")]
        public string? TradeName { get; set; }

        [Display(Name = "businessTypeId")]
        public int BusinessTypeId { get; set; }

        [Display(Name = "taxDocument"), JsonRequired, JsonCnpj]
        public string? TaxDocument { get; set; }

        [Display(Name = "cnaeCode")]
        public int CnaeCode { get; set; }

    }
}