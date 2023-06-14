// using api.Models.EntityModel.Applications;
using api.Models.EntityModel.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Authorization
{
    public class ApiToken
    {
        private readonly AuthOptions _options;

        public ApiToken(AuthOptions options)
        {
            _options = options;
        }

        private byte[] EncodedKey => Encoding.ASCII.GetBytes(_options.Key);
        private byte[] EncodedKey2FA => Encoding.ASCII.GetBytes(_options.Key2FA);

        public DateTime ExpiresIn { get; set; }

        public SymmetricSecurityKey SecurityKey => new SymmetricSecurityKey(EncodedKey);
        public SymmetricSecurityKey SecurityKey2FA => new SymmetricSecurityKey(EncodedKey2FA);

        public SigningCredentials SigningCredentials => new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
        public SigningCredentials SigningCredentials2FA => new SigningCredentials(SecurityKey2FA, SecurityAlgorithms.HmacSha256);

        public string GenerateForEmployee(User user)
        {
            ExpiresIn = DateTime.UtcNow.AddHours(_options.ExpireTokenIn);

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken
            (
                issuer: _options.Issuer,
                audience: _options.Audience,
                notBefore: DateTime.UtcNow,
                signingCredentials: SigningCredentials,
                expires: ExpiresIn,
                claims: new[] {
                    new Claim(ClaimTypes.Actor, "Employee"),
                    new Claim(ApiClaimTypes.UserId, user.PersonId.ToString()),
                    // new Claim(ApiClaimTypes.Salt, user.Salt)
                }
            ));
        }

        public string GenerateForUser(User user)
        {
            ExpiresIn = DateTime.UtcNow.AddHours(_options.ExpireTokenIn);

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken
            (
                issuer: _options.Issuer,
                audience: _options.Audience,
                notBefore: DateTime.UtcNow,
                signingCredentials: SigningCredentials,
                expires: ExpiresIn,
                claims: new[] {
                    new Claim(ClaimTypes.Actor, "User"),
                    // new Claim(ApiClaimTypes.ApplicationId, application.Id.ToString()),
                    // new Claim(ApiClaimTypes.PersonId, user.PersonId.ToString()),
                    new Claim(ApiClaimTypes.UserId, user.PersonId.ToString()),
                    // new Claim(ApiClaimTypes.Salt, user.Salt)
                }
            ));
        }

        // public string GenerateFor2FA(Application application, User user, Person holder, int? expiresIn)
        // {
        //     var token = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken
        //     (
        //         issuer: _options.Issuer2FA,
        //         audience: _options.Audience2FA,
        //         expires: DateTime.UtcNow.AddMinutes(expiresIn ?? _options.Expire2FA),
        //         signingCredentials: SigningCredentials2FA,
        //         claims: new[] {
        //             new Claim(ClaimTypes.Actor, "2FA"),
        //             new Claim(ApiClaimTypes.ApplicationId, application.Id.ToString()),
        //             new Claim(ApiClaimTypes.HolderId, user.HolderId.ToString()),
        //             new Claim(ApiClaimTypes.UserId, user.PersonId.ToString()),
        //         }
        //     ));

        //     return token;
        // }

        public bool Validate2FA(string token)
        {
            var validator = new TokenValidationParameters
            {
                ValidIssuer = _options.Issuer2FA,
                ValidAudience = _options.Audience2FA,
                IssuerSigningKey = SecurityKey2FA,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ValidateActor = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                SecurityToken validatedToken;
                var claimMain = new JwtSecurityTokenHandler().ValidateToken(token, validator, out validatedToken);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}