using BulletStormAPI.Dto;
using BulletStormAPI.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BulletStormAPI.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
              new Claim(ClaimTypes.Name, user.Name),
              new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
              new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtHelper.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your-app",
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
