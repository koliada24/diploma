using Api.Models.Identity;
using System.Security.Claims;

namespace Api.Interfaces
{
    public interface IJwtService
    {        
        string GenerateTokenForUser(User user);

        ClaimsIdentity GetClaimsIdentityFromToken(string token);
    }
}
