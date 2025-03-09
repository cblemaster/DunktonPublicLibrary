
using DunktonPublicLibrary.App.Cryptography;
using DunktonPublicLibrary.App.Domain.Entities;
using DunktonPublicLibrary.App.Infrastructure;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DunktonPublicLibrary.App.Application.LogIn;

public sealed class LogInHandler(AppDbContext context, IPasswordHasher passwordHasher, IValidator<LogInCommand> validator, ITokenGenerator tokenGenerator) : IRequestHandler<LogInCommand, LogInResponse>
{
    private readonly AppDbContext _context = context;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IValidator<LogInCommand> _validator = validator;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

    public async Task<LogInResponse> Handle(LogInCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validation = _validator.Validate(request);
        if (!validation.IsValid)
        {
            return new(ResponseType.ValidationError, validation.ToString());
        }

        Account? account = await _context.Accounts.Include(a => a.Role).SingleOrDefaultAsync(a => a.Credentials.Username.Equals(request.Username), cancellationToken);
        if (account is null)
        {
            return new(ResponseType.AuthenticationError, null);
        }

        bool hashMatch = _passwordHasher.VerifyHashMatch(account.Credentials.PasswordHash, request.Password, account.Credentials.PasswordSalt);
        if (!hashMatch)
        {
            return new(ResponseType.AuthenticationError, null);
        }

        string token = _tokenGenerator.GenerateToken(account.Id.Value, account.Credentials.Username);
        account.Token = token;

        AccountLoggedIn.SetAccount(account);
        return new(ResponseType.Success, token);
    }
}
