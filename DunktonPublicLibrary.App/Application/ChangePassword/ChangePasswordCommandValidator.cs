
using FluentValidation;

namespace DunktonPublicLibrary.App.Application.ChangePassword;

public sealed class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(r => r.Username).NotEmpty().WithMessage(AppConstants.USERNAME_REQUIRED_VALIDATION_ERROR);
        RuleFor(r => r.Username).MaximumLength(DataConstants.USERNAME_MAX_LENGTH).WithMessage(AppConstants.MaxLengthError("{PropertyName}", DataConstants.USERNAME_MAX_LENGTH));

        RuleFor(r => r.NewPassword).NotEmpty().WithMessage(AppConstants.NEW_PASSWORD_REQUIRED_VALIDATION_ERROR);
        RuleFor(r => r.NewPassword).MaximumLength(DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH).WithMessage(AppConstants.MaxLengthError("{PropertyName}", DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH));
        RuleFor(r => r.NewPassword).MinimumLength(DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH).WithMessage(AppConstants.MinLengthError("{PropertyName}", DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH));

        RuleFor(r => r.CurrentPassword).NotEmpty().WithMessage(AppConstants.CURRENT_PASSWORD_REQUIRED_VALIDATION_ERROR);
        RuleFor(r => r.CurrentPassword).MaximumLength(DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH).WithMessage(AppConstants.MaxLengthError("{PropertyName}", DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH));
        RuleFor(r => r.CurrentPassword).MinimumLength(DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH).WithMessage(AppConstants.MinLengthError("{PropertyName}", DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH));
    }
}
