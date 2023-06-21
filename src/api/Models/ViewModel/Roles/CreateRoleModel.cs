using api.Models.EntityModel.Roles;
using api.Validations;
using Newtonsoft.Json;

namespace api.Models.ViewModel.Roles
{
    public class CreateRoleModel
    {
        [JsonProperty("name"), JsonRequiredValidate]
        public string? Name { get; set; }

        [JsonProperty("companyId"), JsonRequiredValidate]
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