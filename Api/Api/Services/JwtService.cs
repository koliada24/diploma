using Api.Interfaces;
using Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Database;

namespace Api.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _db;

        public JwtService(IConfiguration configuration, AppDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        public string GenerateTokenForUser(User user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString())
            };

            var binarySecurityKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])!;
            var secret = new SymmetricSecurityKey(binarySecurityKey);
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            var tokenGenerator = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                signingCredentials: signingCredentials
            );

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.WriteToken(tokenGenerator);

            return token;
        }

        public string GenerateTokenForUsername(string username)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == username);

            var token = GenerateTokenForUser(user);

            return token;
        }
    }
}
