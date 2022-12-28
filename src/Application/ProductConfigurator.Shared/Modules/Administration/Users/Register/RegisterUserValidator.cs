using FluentValidation;

namespace ProductConfigurator.Shared.Modules.Administration.Users;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(Constraints.User.EmailMaxLength).EmailAddress();
        RuleFor(x => x.Password).MaximumLength(100);
    }
}
