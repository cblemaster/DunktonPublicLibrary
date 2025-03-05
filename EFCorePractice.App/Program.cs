
using EFCorePractice.App.Domain;
using EFCorePractice.App.Infrastructure;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configRoot = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

string connectionString = configRoot.GetConnectionString("App") ?? "Error retrieving connection string!";
string jwtSecret = configRoot.GetValue<string>("JwtSecret") ?? "Error retrieving config!";
string[] roles = configRoot.GetSection("Roles").Get<string[]>() ?? [];

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=.;Database=EFCorePractice;Trusted_Connection=true;Trust Server Certificate=true")
    .UseSeeding((context, _) =>
    {
        IQueryable<string> dbRoles = context.Set<Role>().Select(r => r.Name);
        foreach (string role in roles)
        {
            if (!dbRoles.Any(r => r == role))
            {
                context.Set<Role>().Add(new Role() { Name = role, Id = Guid.NewGuid() });
            }
        }
        context.SaveChanges();
    })
    .UseAsyncSeeding(async (context, _, cancelToken) =>
    {
        IQueryable<string> dbRoles = context.Set<Role>().Select(r => r.Name);
        foreach (string role in roles)
        {
            if (!await dbRoles.AnyAsync(r => r == role, cancellationToken: cancelToken))
            {
                await context.Set<Role>().AddAsync(new Role() { Name = role, Id = Guid.NewGuid() }, cancelToken);
            }
        }
        await context.SaveChangesAsync(cancelToken);
    }));

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/test", handler: (AppDbContext context) => context.Accounts.Include(a => a.Role).Select(a => new { AccountId = a.Id, RoleId = a.Role.Id, RoleName = a.Role.Name }).ToList());

app.Run();
