using Api.DTOs;

namespace Api.Interfaces
{
    public interface IUsersService
    {
        Task<Guid> RegisterUser(RegisterUserDTO registerUserDTO);

        Task<bool> ValidateUserCredentials(string userName, string password);
    }
}
