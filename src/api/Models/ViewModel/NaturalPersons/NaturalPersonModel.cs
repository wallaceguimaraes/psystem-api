using System.ComponentModel.DataAnnotations;
using api.Validations;

namespace api.Models.ViewModel.NaturalPersons
{
    public class NaturalPersonModel
    {

        [Display(Name = "fullName")]
        public string? FullName { get; set; }

        [Display(Name = "birthDate")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "gender")]
        public string? Gender { get; set; }

        [Display(Name = "taxDocument"), JsonRequired, JsonCpf]
        public string? TaxDocument { get; set; }
    }
}