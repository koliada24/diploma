using Api.Database;
using Api.DTOs.Identity;
using Api.Interfaces.Identity;
using Api.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Identity
{
    public class UserService : IUsersService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            if (registerUserDTO == null)
            {
                throw new ArgumentNullException(nameof(registerUserDTO));
            }

            if (string.IsNullOrEmpty(registerUserDTO.Username))
            {
                throw new ArgumentException("Username required", nameof(registerUserDTO.Username));
            }

            if (string.IsNullOrEmpty(registerUserDTO.Password))
            {
                throw new ArgumentException("Password required", nameof(registerUserDTO.Username));
            }

            var isUsernameTaken = await _db.Users.AnyAsync(u => u.UserName == registerUserDTO.Username);

            if (isUsernameTaken)
            {
                throw new InvalidOperationException("Username is already taken");
            }

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
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("An error occurred while saving the user to the database.", ex);
            }

            return userToSave;
        }

        public async Task<bool> ValidateUserCredentialsAsync(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Username required", nameof(userName));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password required", nameof(password));
            }

            try
            {
                var matchedUser = await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName);

                if (matchedUser == null)
                {
                    throw new InvalidOperationException("User not found");
                }

                return BCrypt.Net.BCrypt.Verify(password, matchedUser.PasswordHash);
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("An error occurred while accessing the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred during credential validation.", ex);
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username required", nameof(username));
            }

            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);

                if (user == null)
                {
                    throw new InvalidOperationException("User not found");
                }

                return user;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("An error occurred while accessing the database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while retrieving the user.", ex);
            }
        }
    }
}
