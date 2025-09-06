using Api.Models;

namespace Api.Interfaces
{
    public interface IJwtService
    {
        string GenerateTokenForUser(User user);

        string GenerateTokenForUsername(string username);
    }
}
