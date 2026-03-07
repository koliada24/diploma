namespace Authentication.API.Utils
{
    public static class PasswordUtils
    {
        public static string HashPassword(string password)
        {
            // TODO: Implement using hashing logic
            return password;
        }

        public static bool ValidatePassword(string password, string passwordHashToCompare)
        {
            // TODO: Implement using hashing logic
            var isValid = password == passwordHashToCompare;
            
            return isValid;
        }
    }
}
