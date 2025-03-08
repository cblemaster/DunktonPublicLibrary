
using FluentValidation;

namespace DunktonPublicLibrary.App.Application.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(r => r.Username).MaximumLength(DataConstants.USERNAME_MAX_LENGTH).WithMessage($"Username must be {DataConstants.USERNAME_MAX_LENGTH} characters or fewer.");

        RuleFor(r => r.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(r => r.FirstName).MaximumLength(DataConstants.FIRST_NAME_MAX_LENGTH).WithMessage($"First name must be {DataConstants.FIRST_NAME_MAX_LENGTH} characters or fewer.");

        RuleFor(r => r.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(r => r.LastName).MaximumLength(DataConstants.LAST_NAME_MAX_LENGTH).WithMessage($"Last name must be {DataConstants.LAST_NAME_MAX_LENGTH} characters or fewer.");

        RuleFor(r => r.Role).NotEmpty().WithMessage("Role is required.");

        RuleFor(r => r.Password).NotEmpty().WithMessage("Password is required.");
        RuleFor(r => r.Password).MaximumLength(DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH).WithMessage($"Password must be {DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH} characters or fewer.");
        RuleFor(r => r.Password).MinimumLength(DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH).WithMessage($"Password must be at least {DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH} characters.");
    }
}
