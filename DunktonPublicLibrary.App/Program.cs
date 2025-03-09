using DunktonPublicLibrary.App.Extensions;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configRoot = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

string connectionString = configRoot.GetConnectionString("App") ?? "Error retrieving connection string!";
string jwtSecret = configRoot.GetValue<string>("JwtSecret") ?? "Error retrieving config!";
string[] roles = configRoot.GetSection("Roles").Get<string[]>() ?? [];

builder.RegisterDbContext(connectionString, roles);
builder.RegisterServices(jwtSecret);
builder.RegisterAuthenticationAndAuthorization(jwtSecret);

WebApplication app = builder.Build();
app.GetEndpoints();
app.Run();
