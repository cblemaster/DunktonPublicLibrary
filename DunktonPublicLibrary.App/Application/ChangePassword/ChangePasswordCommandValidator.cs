
using FluentValidation;

namespace DunktonPublicLibrary.App.Application.ChangePassword;

public sealed class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(r => r.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(r => r.Username).MaximumLength(DataConstants.USERNAME_MAX_LENGTH).WithMessage($"Username must be {DataConstants.USERNAME_MAX_LENGTH} characters or fewer.");

        RuleFor(r => r.NewPassword).NotEmpty().WithMessage("New password is required.");
        RuleFor(r => r.NewPassword).MaximumLength(DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH).WithMessage($"New password must be {DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH} characters or fewer.");
        RuleFor(r => r.NewPassword).MinimumLength(DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH).WithMessage($"New password must be at least {DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH} characters.");

        RuleFor(r => r.CurrentPassword).NotEmpty().WithMessage("Current password is required.");
        RuleFor(r => r.CurrentPassword).MaximumLength(DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH).WithMessage($"Current password must be {DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH} characters or fewer.");
        RuleFor(r => r.CurrentPassword).MinimumLength(DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH).WithMessage($"Current password must be at least {DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH} characters.");
    }
}
