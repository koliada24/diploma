using Api.Database;
using Api.DTOs;
using Api.Interfaces;
using Api.Models.Identity;
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

        public async Task<User?> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            var guid = Guid.NewGuid();

            var userToSave = new User
            {
                Id = guid,
                UserName = registerUserDTO.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password)
            };
            
            _db.Users.Add(userToSave);
            await _db.SaveChangesAsync();

            return userToSave;
        }

        public async Task<bool> ValidateUserCredentialsAsync(string userName, string password)
        {
            var matchedUser = await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (matchedUser == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(password, matchedUser.PasswordHash);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);

            return user;
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }
    }
}
