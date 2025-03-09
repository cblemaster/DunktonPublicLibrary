
using DunktonPublicLibrary.App.Application.ChangePassword;
using DunktonPublicLibrary.App.Application.Register;
using DunktonPublicLibrary.App.Cryptography;
using DunktonPublicLibrary.App.Domain.Entities;
using DunktonPublicLibrary.App.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DunktonPublicLibrary.App;

public static class WebAppBuilderExtensions
{
    public static void RegisterDbContext(this WebApplicationBuilder builder, string connectionString, string[] roles) =>
        builder.Services.AddDbContext<AppDbContext>(options => options
            .UseSqlServer(connectionString)
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
                    if (!await dbRoles.AnyAsync(r => r == role, cancelToken))
                    {
                        await context.Set<Role>().AddAsync(Role.CreateForDataSeeding(role), cancelToken);
                    }
                }
                await context.SaveChangesAsync(cancelToken);
            }));

    public static void RegisterServices(this WebApplicationBuilder builder, string jwtSecret)
    {
        builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
        builder.Services.AddSingleton<ITokenGenerator>(j => new JwtGenerator(jwtSecret));
        builder.Services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
        builder.Services.AddScoped<IValidator<ChangePasswordCommand>, ChangePasswordCommandValidator>();
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
    }

    public static void RegisterAuthenticationAndAuthorization(this WebApplicationBuilder builder, string jwtSecret)
    {
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[JwtRegisteredClaimNames.Sub] = "sub";
        byte[] key = Encoding.ASCII.GetBytes(jwtSecret);
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

        builder.Services.AddAuthorizationBuilder().AddPolicy("requires_auth", policy => policy.RequireAuthenticatedUser());
    }
}
