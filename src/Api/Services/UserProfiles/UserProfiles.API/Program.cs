using Identity;
using Microsoft.EntityFrameworkCore;
using UserProfiles.API.Database;
using UserProfiles.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    options.UseNpgsql(connectionString);
});
builder.Services.AddControllers();
builder.AddIdentity();

builder.Services.AddScoped<IUserPublicProfilesService, UserPublicProfilesService>();
builder.Services.AddScoped<IStudentsGroupsService, StudentsGroupsService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapControllers();
app.UseIdentity();

app.Run();
