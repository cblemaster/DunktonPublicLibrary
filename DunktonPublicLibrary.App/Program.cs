
using DunktonPublicLibrary.App.Application;
using DunktonPublicLibrary.App.Application.Register;
using DunktonPublicLibrary.App.Cryptography;
using DunktonPublicLibrary.App.Domain.Entities;
using DunktonPublicLibrary.App.Infrastructure;
using DunktonPublicLibrary.App.Validation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configRoot = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

string connectionString = configRoot.GetConnectionString("App") ?? "Error retrieving connection string!";
string jwtSecret = configRoot.GetValue<string>("JwtSecret") ?? "Error retrieving config!";
string[] roles = configRoot.GetSection("Roles").Get<string[]>() ?? [];

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
    .UseSeeding((context, _) =>
    {
        IQueryable<string> dbRoles = context.Set<Role>().Select(r => r.Name);
        foreach (string role in roles)
        {
            if (!dbRoles.Any(r => r == role))
            {
                context.Set<Role>().Add(Role.CreateForDataSeeding(role));
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
                await context.Set<Role>().AddAsync(Role.CreateForDataSeeding(role), cancelToken);
            }
        }
        await context.SaveChangesAsync(cancelToken);
    }));

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<ITokenGenerator>(j => new JwtGenerator(jwtSecret));
builder.Services.AddScoped<IRepository<Account>, Repository<Account>>();
builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
builder.Services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

byte[] key = Encoding.ASCII.GetBytes(jwtSecret);
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[JwtRegisteredClaimNames.Sub] = "sub";

builder.Services.AddAuthentication(a =>
{
    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(b =>
{
    b.RequireHttpsMetadata = false;
    b.SaveToken = true;
    b.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        NameClaimType = "name"
    };
});

builder.Services.AddAuthorizationBuilder().AddPolicy("requireauthuser", policy => policy.RequireAuthenticatedUser());


WebApplication app = builder.Build();

app.MapGet("/", () => "Welcome to Dunkton Public Library!");
app.MapPost("/register", handler: async Task<Results<BadRequest<string>, InternalServerError, Created>> (RegisterCommand command, IMediator mediator) =>
{
    RegisterResponse response = await mediator.Send(command);
    return response.ResponseType switch
    {
        ResponseType.ValidationError => TypedResults.BadRequest(response.Message),
        ResponseType.Success => TypedResults.Created(),
        _ => TypedResults.InternalServerError(),
    };
});

app.Run();
