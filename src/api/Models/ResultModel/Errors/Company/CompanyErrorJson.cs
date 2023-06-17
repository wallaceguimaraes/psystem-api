using api.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace api.Results.v2.Users
{
    public class CompanyErrorJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("USER_NOT_FOUND").ExecuteResultAsync(context);
        }
    }
}