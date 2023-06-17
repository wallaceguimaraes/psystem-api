using System.ComponentModel.DataAnnotations;
using api.Models.EntityModel.Roles;
using api.Validations;

namespace api.Models.ViewModel.Roles
{
    public class CreateRoleModel
    {
        [Display(Name = "name"), JsonRequired]
        public string? Name { get; set; }

        [Display(Name = "companyId"), JsonRequired]
        public string? CompanyId { get; set; }


        public Role Map()
        {
            return new Role
            {
                Name = Name,
                CompanyId = Convert.ToInt32(CompanyId)
            };
        }
    }
}