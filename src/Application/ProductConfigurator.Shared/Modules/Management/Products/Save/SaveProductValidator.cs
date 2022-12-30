using FluentValidation;

namespace ProductConfigurator.Shared.Modules.Management.Products;

public class SaveProductValidator : AbstractValidator<SaveProductRequest>
{
    public SaveProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(Constraints.Product.NameMaxLength);
        RuleFor(x => x.Description).MaximumLength(Constraints.Product.DescriptionMaxLength);
    }
}
