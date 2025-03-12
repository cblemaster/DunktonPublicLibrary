
using DunktonPublicLibrary.App.Cryptography;
using DunktonPublicLibrary.App.Domain.Entities;
using DunktonPublicLibrary.App.Infrastructure;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DunktonPublicLibrary.App.Application.ChangePassword;

public sealed class ChangePasswordHandler(AppDbContext context, IPasswordHasher passwordHasher, IValidator<ChangePasswordCommand> validator) : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    private readonly AppDbContext _context = context;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IValidator<ChangePasswordCommand> _validator = validator;

    public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        if (request.NewPassword.Equals(request.CurrentPassword))
        {
            return new(ResponseType.ValidationError, "New and current passwords cannot be the same.");
        }

        ValidationResult validation = _validator.Validate(request);
        if (!validation.IsValid)
        {
            return new(ResponseType.ValidationError, validation.ToString());
        }

        Account? account = await _context.Accounts.SingleOrDefaultAsync(a => a.Credentials.Username.Equals(request.Username), cancellationToken);
        if (account is null)
        {
            return new(ResponseType.AuthenticationError, null);
        }

        bool hashMatch = _passwordHasher.VerifyHashMatch(account.Credentials.PasswordHash, request.CurrentPassword, account.Credentials.PasswordSalt);
        if (!hashMatch)
        {
            return new(ResponseType.AuthenticationError, null);
        }

        PasswordHash hash = _passwordHasher.ComputeHash(request.NewPassword);
        account.Credentials = account.Credentials with { PasswordHash = hash.Hash, PasswordSalt = hash.Salt };
        account.Dates = account.Dates with { UpdateDate = DateTime.UtcNow };
        await _context.SaveChangesAsync(cancellationToken);

        AccountLoggedIn.SetAccount(null);
        
        return new(ResponseType.Success, null);
    }
}
