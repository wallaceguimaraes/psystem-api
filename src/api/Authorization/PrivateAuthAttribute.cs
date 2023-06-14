using api.Extensions;
using api.Extensions.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace api.Authorization
{
    public class PrivateAuthAttribute : ActionFilterAttribute
    {
        private readonly string[] _ipSafelistScopes;

        public PrivateAuthAttribute(params string[] ipSafelistScopes)
        {
            _ipSafelistScopes = ipSafelistScopes;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<PrivateAuthAttribute>>();
            var authOptions = context.HttpContext.RequestServices.GetRequiredService<IOptions<AuthOptions>>().Value;

            var allowedIpAddresses = new HashSet<string>();
            foreach (var safelistScope in _ipSafelistScopes)
            {
                var ipAddresses = authOptions.IpSafelist?.GetValueOrDefault(safelistScope);
                if (ipAddresses == null)
                    continue;

                foreach (var ipAddress in ipAddresses)
                {
                    allowedIpAddresses.Add(ipAddress.Trim());
                }
            }

            var secret = context.HttpContext.Request.Query["secret"].ToString();
            var validSecret = !string.IsNullOrWhiteSpace(secret) && secret.Equals(authOptions.Secret);

            var remoteIpAddress = context.HttpContext.ClientIp().FirstWord(',').Trim();
            var validIp = authOptions.DisableIpSafelistCheck == null || authOptions.DisableIpSafelistCheck.Value || allowedIpAddresses.Contains(remoteIpAddress.ToString());

            if (!authOptions.DisableIpSafelistLog)
                logger.LogError($"A private request occurred.  \n\n Remote IpAddress: {remoteIpAddress}");

            if (!validIp || !validSecret)
            {
                logger.LogError($"Private request unauthorized.  \n\n IpAddress: {remoteIpAddress}  \n IP valid: {validIp} \n Secret valid: {validSecret}");
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
