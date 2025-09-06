using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AppBaseController : ControllerBase
    {
        protected Guid UserId => GetUserIdFromHttpContext();
        protected string Username => GetUsernameFromHttpContext();

        private Guid GetUserIdFromHttpContext()
        {
            var userIdFromContext = HttpContext.Items["UserId"]?.ToString() ?? string.Empty;

            if (userIdFromContext == string.Empty || !Guid.TryParse(userIdFromContext, out var userId))
            {
                return Guid.Empty;
            }

            return userId;
        }
        
        private string GetUsernameFromHttpContext()
        {
            var usernameFromContext = HttpContext.Items["Username"]?.ToString() ?? string.Empty;

            return usernameFromContext;
        }
    }
}
