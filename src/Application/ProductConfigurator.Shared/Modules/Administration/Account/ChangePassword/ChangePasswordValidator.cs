using FluentValidation;

namespace ProductConfigurator.Shared.Modules.Administration.Account;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordValidator()
    {
        //RuleFor(x => x.CurrentPassword).MaximumLength(100);
        RuleFor(x => x.NewPassword).MaximumLength(100);
    }
}
