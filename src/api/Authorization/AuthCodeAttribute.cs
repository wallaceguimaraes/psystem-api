using api.Models.ServiceModel;
using api.Models.ViewModel.v2.Authentication;
using api.Results.Errors;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Authorization
{
    public class AuthCodeAttribute : ActionFilterAttribute
    {
        private const string authCodeField = "AUTHCODE";

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userAuthenticationService = context.HttpContext.RequestServices.GetService<UserAuthentication>();
            var authCode = context.HttpContext.Request.Headers
                .SingleOrDefault(header => header.Key.ToUpper() == authCodeField).Value.ToString();
            var claims = context.HttpContext.User.Claims;

            if (string.IsNullOrEmpty(authCode))
            {
                context.Result = new BadRequestJson("authCode: required");
                return;
            }

            if (!int.TryParse(authCode, out int code))
            {
                context.Result = new BadRequestJson("authCode: invalid");
                return;
            }

            var authCodeValidation = new AuthCodeValidate
            {
                Code = code,
            };

            // await userAuthenticationService.FindUser(claims.UserId());
            // var response = await userAuthenticationService.ValidateAuthCode(authCodeValidation);
            var response = true;
            if (response)
            {
                await next();
            }

            context.Result = new UnprocessableEntityJson("AUTH_CODE_INVALID");
        }
    }
}
