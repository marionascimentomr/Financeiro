using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Pay.Domain.Interfaces.Security;
using Pay.Domain.ValueObjects;
using Pay.Infra.Security.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pay.Infra.Security.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenSettings _tokenSettings;
        public TokenService(IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings.Value;
        }
        public string CreateToken(UserAuthV0 userAuth)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(userAuth)),
                new Claim(ClaimTypes.Role, userAuth.Role)
            };

            var key = new SymmetricSecurityKey

            (Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
            issuer: _tokenSettings.Issuer,
            audience: _tokenSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes

            (Convert.ToDouble(_tokenSettings.ExpirationInMinutes)), signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
