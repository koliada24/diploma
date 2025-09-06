using Api.DTOs;
using Api.Models;

namespace Api.Interfaces
{
    public interface IUsersService
    {
        Task<User?> RegisterUser(RegisterUserDTO registerUserDTO);

        Task<bool> ValidateUserCredentials(string userName, string password);

        Task<User?> GetUserByUsername(string username);
    }
}
