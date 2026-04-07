using Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.AddIdentity();

var app = builder.Build();

app.MapControllers();
app.UseIdentity();

app.Run();
