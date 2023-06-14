using api.Authorization;
using System.Security.Claims;

namespace api.Extensions.Identity
{
    public static class ClaimsExtensions
    {
        public static string? Actor(this IEnumerable<Claim> claims)
        {
            var claim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor);
            return claim?.Value;
        }

        public static long ApplicationId(this IEnumerable<Claim> claims)
        {
            var claim = claims.FirstOrDefault(c => c.Type == ApiClaimTypes.ApplicationId);
            var userId = 0L;

            Int64.TryParse(claim?.Value, out userId);

            return userId;
        }

        public static long UserId(this IEnumerable<Claim> claims)
        {
            var claim = claims.FirstOrDefault(c => c.Type == ApiClaimTypes.UserId);
            var userId = 0L;

            Int64.TryParse(claim?.Value, out userId);

            return userId;
        }

        // public static long HolderId(this IEnumerable<Claim> claims)
        // {
        //     var claim = claims.FirstOrDefault(c => c.Type == ApiClaimTypes.HolderId);
        //     var ownerId = 0L;

        //     Int64.TryParse(claim?.Value, out ownerId);

        //     return ownerId;
        // }

        public static string? Salt(this IEnumerable<Claim> claims)
        {
            var claim = claims.FirstOrDefault(c => c.Type == ApiClaimTypes.Salt);

            return claim?.Value;
        }

        // public static bool HolderAsEmployee(this IEnumerable<Claim> claims)
        // {
        //     var claim = claims.FirstOrDefault(c => c.Type == ApiClaimTypes.HolderAsEmployee);

        //     return claim?.Value == true.ToString() ? true : false;
        // }
    }
}