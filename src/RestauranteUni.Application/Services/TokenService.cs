using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestauranteUni.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestauranteUni.Application.Services
{
    public sealed class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly DateTime _defaultExpirationTime = DateTime.Now.AddMinutes(30);
        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string WriteToken<T>(T id, string sub, List<Claim> claims, DateTime? expiration = null)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            claims.Add(new Claim(ClaimTypes.Email, sub));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
            var token = new JwtSecurityToken
            (
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expiration ?? _defaultExpirationTime,
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
