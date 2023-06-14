using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace api.Extensions.Http
{
    public static class HttpContextExtensions
    {
        private const int CharacterLimitForIP = 150;

        public static string Token(this HttpContext httpContext)
        {
            return httpContext.Request.Headers[HeaderNames.Authorization];
        }

        public static string ClientIp(this HttpContext httpContext)
        {
            var logger = httpContext.RequestServices.GetRequiredService<ILogger<HttpContext>>();

            string ip;
            var headers = httpContext.Request.Headers.ToList();
            if (headers.Exists((kvp) => kvp.Key == "X-Forwarded-For"))
            {
                // when running behind a load balancer you can expect this header
                ip = headers.First((kvp) => kvp.Key == "X-Forwarded-For").Value.ToString();
            }
            else
            {
                // this will always have a value (running locally in development won't have the header)
                ip = httpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            if (ip.Length > CharacterLimitForIP)
            {
                logger.LogError($"The following IP has exceeded character limit: Original IP length: ({ip.Length}) | Original IP: {ip}");
                ip = ip.Truncate(150);
            }

            return ip;
        }
    }
}