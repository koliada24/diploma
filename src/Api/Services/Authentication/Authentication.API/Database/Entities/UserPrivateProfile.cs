namespace Authentication.API.Database.Entities
{
    public class UserPrivateProfile
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Examinator,
        Student
    }
}
