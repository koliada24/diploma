using Api.Database;
using Api.DTOs;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class UserService : IUsersService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var guid = Guid.NewGuid();

            var userToSave = new User
            {
                Id = guid,
                UserName = registerUserDTO.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password)
            };

            try
            {
                _db.Users.Add(userToSave);
                await _db.SaveChangesAsync();
            }
            catch
            {
                return Guid.Empty;
            }

            return guid;
        }

        public async Task<bool> ValidateUserCredentials(string userName, string password)
        {
            var matchedUser = await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (matchedUser == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(password, matchedUser.PasswordHash);
        }
    }
}
