using Api.Interfaces;
using System.Security.Claims;

namespace Api.Middlewares
{
    public class IdentityMiddleware
    {
        private readonly RequestDelegate _next;

        public IdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IJwtService jwtService)
        {
            var token = context.Request.Cookies["jwt_token"] ?? string.Empty;
            
            if (token == string.Empty)
            {
                context.Items["UserId"] = string.Empty;
                context.Items["Username"] = string.Empty;
                await _next(context);
                return;
            }

            var identity = jwtService.GetClaimsIdentityFromToken(token);

            var userId = identity.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            var userName = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            context.Items["UserId"] = userId;
            context.Items["Username"] = userName;

            await _next(context);
            return;
        }
    }
}
