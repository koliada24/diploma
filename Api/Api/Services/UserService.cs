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

        public async Task<User?> RegisterUser(RegisterUserDTO registerUserDTO)
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

        public async Task<bool> ValidateUserCredentials(string userName, string password)
        {
            var matchedUser = await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (matchedUser == null)
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(password, matchedUser.PasswordHash);
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);

            return user;
        }
    }
}
