using ASPWebAPI.Services.Interface;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using SharedLibrary.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASPWebAPI.Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly string _key;
        private readonly string _issuer;

        public TokenService(IOptions<TokenServiceOptions> options)
        {
            _key = options.Value.Key;
            _issuer = options.Value.Issuer;
        }

        public string? GenerateToken(LoginRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key);

            if (request.Email != null)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, request.Email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    Issuer = _issuer,
                    Audience = _issuer,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null;

        }
    }
}
