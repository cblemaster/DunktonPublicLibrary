
using FluentValidation;

namespace DunktonPublicLibrary.App.Application.LogIn;

public sealed class LoginCommandValidator : AbstractValidator<LogInCommand>
{
    public LoginCommandValidator()
    {
        // TODO: reduce duplication of validation rules?
        RuleFor(r => r.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(r => r.Username).MaximumLength(DataConstants.USERNAME_MAX_LENGTH).WithMessage($"Username must be {DataConstants.USERNAME_MAX_LENGTH} characters or fewer.");

        RuleFor(r => r.Password).NotEmpty().WithMessage("Password is required.");
        RuleFor(r => r.Password).MaximumLength(DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH).WithMessage($"Password must be {DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH} characters or fewer.");
        RuleFor(r => r.Password).MinimumLength(DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH).WithMessage($"Password must be at least {DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH} characters.");
    }
}
