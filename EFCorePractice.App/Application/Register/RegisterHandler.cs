
using EFCorePractice.App.Cryptography;
using EFCorePractice.App.Domain.Entities;
using EFCorePractice.App.Domain.ValueObjects;
using EFCorePractice.App.Infrastructure;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EFCorePractice.App.Application.Register;

public sealed class RegisterHandler(AppDbContext context, IPasswordHasher passwordHasher, IValidator<RegisterCommand> validator) : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly AppDbContext _context = context;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IValidator<RegisterCommand> _validator = validator;
    
    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validation = _validator.Validate(request);
        if (!validation.IsValid)
        {
            return new(ResponseType.ValidationError, validation.ToString());
        }

        if (_context.Set<Account>().Select(a => a.Credentials.Username).Contains(request.Username))
        {
            return new(ResponseType.ValidationError, $"Username {request.Username} is used by another account, usernames must be unique.");
        }
        
        Role? role = await _context.Set<Role>().SingleOrDefaultAsync(r => r.Name.Equals(request.Username), cancellationToken: cancellationToken);
        if (role is null)
        {
            return new(ResponseType.NotFoundError, null);
        }
        
        PasswordHash hash = _passwordHasher.ComputeHash(request.Password);
        Credentials credentials = new Credentials(request.Username, hash.Hash, hash.Salt);
        Names names = new Names(request.FirstName, request.LastName);
        
        Account newAccount = new(role, credentials, names);
        await _context.AddAsync<Account>(newAccount);
        await _context.SaveChangesAsync();
        return new(ResponseType.Success, null);
    }
}
