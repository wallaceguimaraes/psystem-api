using api.Models.EntityModel.Roles;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Successes.Roles
{
    public class RoleJson : IActionResult
    {
        public RoleJson() { }

        public RoleJson(Role role)
        {
            Id = role.Id.ToString();
            Name = role.Name;
            Active = role.Active;
            CompanyId = role.CompanyId.ToString();
            CreatedAt = role.CreatedAt;

        }

        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string CompanyId { get; set; }
        public DateTime CreatedAt { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}