using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.API.Database.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.API.Utils
{
    public static class JwtUtils
    {
        public static string GenerateJWT(UserPrivateProfile user, IConfiguration config)
        {
            var key = config["Jwt:Key"];
            if (string.IsNullOrEmpty(key))
            {
                throw new InvalidOperationException("JWT signing key is not configured.");
            }

            var issuer = config.GetValue("Jwt:Issuer", "Authentication.API");
            var audience = config.GetValue("Jwt:Audience", "Authentication.API.Client");
            var minutes = config.GetValue("Jwt:AccessTokenMinutes", 15);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Login),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(minutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
