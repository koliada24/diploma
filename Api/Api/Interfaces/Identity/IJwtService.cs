using Api.Models.Identity;
using System.Security.Claims;

namespace Api.Interfaces.Identity
{
    public interface IJwtService
    {        
        string GenerateTokenForUser(User user);

        ClaimsIdentity GetClaimsIdentityFromToken(string token);
    }
}
