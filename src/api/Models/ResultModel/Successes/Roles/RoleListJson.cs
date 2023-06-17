using api.Models.EntityModel.Roles;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Successes.Roles
{
    public class RoleListJson : IActionResult
    {
        public RoleListJson() { }

        public RoleListJson(ICollection<Role> roles, long count)
        {
            Roles = roles.Select(role => new RoleJson(role)).ToList();
            Count = count;
        }

        public ICollection<RoleJson> Roles { get; set; }
        public long Count { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}