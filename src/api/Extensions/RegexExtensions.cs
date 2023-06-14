using System.Text.RegularExpressions;

namespace api.Extensions
{
    public static class RegexExtensions
    {
        private static IHttpContextAccessor? _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static bool SafeIsMatch(string input, string pattern, TimeSpan? timeout = null)
        {

            TimeSpan actualTimeout = timeout ?? TimeSpan.FromMilliseconds(100);

            try
            {
                return Regex.IsMatch(input, pattern, RegexOptions.None, actualTimeout);
            }
            catch (RegexMatchTimeoutException)
            {
                HttpContext httpContext = _httpContextAccessor.HttpContext;

                var logger = httpContext.RequestServices.GetRequiredService<ILogger<HttpContext>>();
                logger.LogError($"The operation has timed out. \n\n Pattern: {pattern} \n\n Input: {input}");

                return false;
            }
        }

        public static string SafeReplace(string input, string pattern, string replacement, TimeSpan? timeout = null)
        {
            TimeSpan actualTimeout = timeout ?? TimeSpan.FromMilliseconds(100);

            try
            {
                Regex regex = new Regex(pattern, RegexOptions.None, actualTimeout);
                return regex.Replace(input, replacement);
            }
            catch (RegexMatchTimeoutException)
            {
                HttpContext httpContext = _httpContextAccessor.HttpContext;

                var logger = httpContext.RequestServices.GetRequiredService<ILogger<HttpContext>>();
                logger.LogError($"The replace operation timed out. \n\n Pattern: {pattern} \n\n Input: {input}");

                return input;
            }
        }
    }
}
