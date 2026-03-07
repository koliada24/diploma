using Authentication.API.Database;
using Microsoft.EntityFrameworkCore;
using Authentication.API.Services;
using Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IUserPrivateProfilesService, UserPrivateProfilesService>();
builder.AddIdentity();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapControllers();

app.UseIdentity();

app.Run();