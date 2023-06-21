using api.Models.EntityModel.Users;
using api.Models.IntegrationModel.Model;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel.Successes
{
    public class WhoAmIJson : IActionResult
    {
        public WhoAmIJson(WhoAmI whoAmI)
        {
            User = whoAmI.User;
        }

        public User User { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}