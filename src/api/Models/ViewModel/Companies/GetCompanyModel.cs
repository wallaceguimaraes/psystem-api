using System.ComponentModel.DataAnnotations;

namespace api.Models.ViewModel.Companies
{
    public class GetCompanyModel
    {
        [Display(Name = "companyId")]
        public string? CompanyId { get; set; }
    }
}