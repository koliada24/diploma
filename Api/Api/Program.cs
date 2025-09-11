using Api.Database;
using Api.Interfaces.Exams;
using Api.Interfaces.Identity;
using Api.Middlewares;
using Api.Services.Exams;
using Api.Services.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                string? connectionString = Environment.GetEnvironmentVariable("diploma-dev", EnvironmentVariableTarget.User);
                options.UseNpgsql(connectionString);
            });

            builder.Services.AddScoped<IUsersService, UserService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IExamsService, ExamsService>();

            builder.Services.AddCors(builder =>
            {
                builder.AddPolicy("LocalDevelopment", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });
            builder.Services.AddControllers();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }

            app.UseCors("LocalDevelopment");
            app.UseMiddleware<IdentityMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}
