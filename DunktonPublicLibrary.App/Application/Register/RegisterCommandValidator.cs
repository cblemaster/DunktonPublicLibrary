
using FluentValidation;

namespace DunktonPublicLibrary.App.Application.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.Username).NotEmpty().WithMessage(AppConstants.USERNAME_REQUIRED_VALIDATION_ERROR);
        RuleFor(r => r.Username).MaximumLength(DataConstants.USERNAME_MAX_LENGTH).WithMessage(AppConstants.MaxLengthError("{PropertyName}", DataConstants.USERNAME_MAX_LENGTH));

        RuleFor(r => r.FirstName).NotEmpty().WithMessage(AppConstants.FIRST_NAME_REQUIRED_VALIDATION_ERROR);
        RuleFor(r => r.FirstName).MaximumLength(DataConstants.FIRST_NAME_MAX_LENGTH).WithMessage(AppConstants.MaxLengthError("{PropertyName}", DataConstants.FIRST_NAME_MAX_LENGTH));

        RuleFor(r => r.LastName).NotEmpty().WithMessage(AppConstants.LAST_NAME_REQUIRED_VALIDATION_ERROR);
        RuleFor(r => r.LastName).MaximumLength(DataConstants.LAST_NAME_MAX_LENGTH).WithMessage(AppConstants.MaxLengthError("{PropertyName}", DataConstants.LAST_NAME_MAX_LENGTH));

        RuleFor(r => r.Role).NotEmpty().WithMessage(AppConstants.ROLE_REQUIRED_VALIDATION_ERROR);

        RuleFor(r => r.Password).NotEmpty().WithMessage(AppConstants.PASSWORD_REQUIRED_VALIDATION_ERROR);
        RuleFor(r => r.Password).MaximumLength(DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH).WithMessage(AppConstants.MaxLengthError("{PropertyName}", DataConstants.PLAINTEXT_PASSWORD_MAX_LENGTH));
        RuleFor(r => r.Password).MinimumLength(DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH).WithMessage(AppConstants.MinLengthError("{PropertyName}", DataConstants.PLAINTEXT_PASSWORD_MIN_LENGTH));
    }
}
