using Microsoft.AspNetCore.Builder;

namespace Identity
{
    public static class WebApplicationExtention
    {
        public static WebApplication UseIdentity(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
