using api.Results.Errors;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace api.Authorization
{
    public class Auth2FAAttribute : ActionFilterAttribute
    {
        private const string headerField = "2FA";

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var authOptions = context.HttpContext.RequestServices.GetService<IOptions<AuthOptions>>().Value;
            var apiToken = new ApiToken(authOptions);

            var token = context.HttpContext.Request.Headers
                .SingleOrDefault(header => header.Key.ToUpper() == headerField)
                .Value.ToString();

            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = new BadRequestJson($"{headerField}: required");

                return;
            }

            if (!apiToken.Validate2FA(token))
            {
                context.Result = new UnprocessableEntityJson("2FA_TOKEN_INVALID");

                return;
            }

            await next();
        }
    }
}
