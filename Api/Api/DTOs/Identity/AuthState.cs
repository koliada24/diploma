namespace Api.DTOs.Identity
{
    public class AuthState
    {
        public bool IsAuthenticated { get; set; } = false;
        public string CurrentUserName { get; set; } = string.Empty;
    }
}
