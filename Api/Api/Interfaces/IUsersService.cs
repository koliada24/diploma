using Api.DTOs;
using Api.Models.Identity;

namespace Api.Interfaces
{
    public interface IUsersService
    {
        Task<User?> RegisterUserAsync(RegisterUserDTO registerUserDTO);

        Task<bool> ValidateUserCredentialsAsync(string userName, string password);

        Task<User?> GetUserByUsernameAsync(string username);

        Task<User?> GetUserByIdAsync(Guid userId);
    }
}
