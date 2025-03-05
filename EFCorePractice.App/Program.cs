
using EFCorePractice.App.Domain;
using EFCorePractice.App.Infrastructure;
using Microsoft.EntityFrameworkCore;

string[] roles = ["admin", "cardholder", "junior_reader"];

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
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

app.Run();
