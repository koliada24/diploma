using Api.Database;
using Api.Interfaces;
using Api.Services;
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

            app.UseCors("LocalDevelopment");
            app.MapControllers();

            app.Run();
        }
    }
}
