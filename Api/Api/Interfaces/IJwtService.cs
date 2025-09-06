using Api.Models;
using System.Security.Claims;

namespace Api.Interfaces
{
    public interface IJwtService
    {        
        string GenerateTokenForUser(User user);

        ClaimsIdentity GetClaimsIdentityFromToken(string token);

        Guid GetUserIdFromToken(string token);
    }
}
