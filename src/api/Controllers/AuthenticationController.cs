using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Authorization;
using api.Models.ServiceModel;
using api.Models.ViewModel;
using api.ResultModel.Successes.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers
{
    [Route("api/v1")]
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserAuthentication _userAuthentication;
        // private readonly IServiceProvider _serviceProvider;
        private readonly AuthOptions _options;
        private byte[] EncodedKey => Encoding.ASCII.GetBytes(_options.Key);

        public SymmetricSecurityKey SecurityKey => new SymmetricSecurityKey(EncodedKey);

        public SigningCredentials SigningCredentials => new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

        public AuthenticationController(ILogger<AuthenticationController> logger,
// IServiceProvider serviceProvider
UserAuthentication userAuthentication
)
        {
            _logger = logger;
            // _serviceProvider = serviceProvider;
            _userAuthentication = userAuthentication;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] CredentialsViewModel model)
        {
            // Implemente sua lógica de autenticação aqui
            // Verifique as credenciais do usuário e retorne um token válido
            // if()

            // var serviceProvider = _serviceProvider.GetRequiredService<UserAuthentication>();

            // var test=serviceProvider.User.Salt;
            if (await _userAuthentication.SignIn(model.Email, model.Password))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, model.Email),
                    new Claim(ApiClaimTypes.PersonId, _userAuthentication.User.PersonId.ToString()),
                    new Claim(ApiClaimTypes.Salt, _userAuthentication.User.Salt)
                };

                // Gera o token JWT
                // var tokenKey = "sua_chave_secreta_aqui"; // A mesma chave usada na configuração da autenticação
                var token = new JwtSecurityToken(
                        issuer: _options.Issuer,
                        audience: _options.Audience,
                        notBefore: DateTime.UtcNow,
                        signingCredentials: SigningCredentials,
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(1) // Tempo de expiração do token
                                                             // signingCredentials: new SigningCredentials(
                                                             //     new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                                                             //     SecurityAlgorithms.HmacSha256)
                );

                return new TokenJson(new JwtSecurityTokenHandler().WriteToken(token), DateTime.UtcNow.AddHours(_options.ExpireTokenIn));

            }

            return Unauthorized();
        }
    }
}