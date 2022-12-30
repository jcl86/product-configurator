using FluentValidation;

namespace ProductConfigurator.Shared.Modules.Management.Steps.Save;

public class SaveStepValidator : AbstractValidator<SaveStepRequest>
{
    public SaveStepValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(Constraints.Step.NameMaxLength);
        RuleForEach(x => x.Options).SetValidator(new OptionValidator());
        RuleForEach(x => x.Conditions).SetValidator(new ConditionValidator());
    }

    public class OptionValidator : AbstractValidator<SaveStepRequest.Option>
    {
        public OptionValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(Constraints.Option.NameMaxLength);
            RuleFor(x => x.Description).MaximumLength(Constraints.Option.DescriptionMaxLength);
        }
    }

    public class ConditionValidator : AbstractValidator<SaveStepRequest.Condition>
    {
        public ConditionValidator()
        {
            RuleForEach(x => x.Tags).NotEmpty();
        }
    }
}