using Authentication.API.Database;
using Authentication.API.Database.Entities;
using Authentication.API.Models;
using Authentication.API.Utils;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API.Services
{
    public interface IUserPrivateProfilesService
    {
        public Task<UserPrivateProfile> RegisterUserAsync(RegisterRequest request);
    }

    public class UserPrivateProfilesService : IUserPrivateProfilesService
    {
        private readonly AppDbContext _db;

        public UserPrivateProfilesService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<UserPrivateProfile> RegisterUserAsync(RegisterRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Invalid request");
            }

            if (string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password))
            {
                throw new ArgumentException("Login and password are required");
            }

            if (!Enum.TryParse<UserRole>(request.Role, true, out var role))
            {
                throw new ArgumentException("Invalid role");
            }

            var exists = await _db.UserPrivateProfiles.AnyAsync(u => u.Login == request.Login);
            if (exists)
            {
                throw new InvalidOperationException("User with such login already exists");
            }

            var passwordHash = PasswordUtils.HashPassword(request.Password);

            var user = new UserPrivateProfile
            {
                Id = Guid.NewGuid(),
                Login = request.Login,
                PasswordHash = passwordHash,
                Role = role
            };

            _db.UserPrivateProfiles.Add(user);
            await _db.SaveChangesAsync();

            return user;
        }
    }
}
