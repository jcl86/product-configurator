using Bogus;
using Bogus.DataSets;

using ProductConfigurator.FunctionalTests.Scenarios.Administration.Account;
using ProductConfigurator.FunctionalTests.Scenarios.Administration.Users;
using ProductConfigurator.Shared.Modules.Administration.Users;
using ProductConfigurator.Shared.Modules.Management.Products;

namespace ProductConfigurator.FunctionalTests.Scenarios.Management.Products;

public class ProductMother
{
    public static SaveProductRequest Create(int steps = 2)
    {
        IEnumerable<SaveProductRequest.Step> stepList = Enumerable.Range(1, steps).Select(x => new SaveProductRequest.Step
        {
            Id = x,
            Name = $"Step {x}",
            Order = 1
        });

        Faker<SaveProductRequest> faker = new Faker<SaveProductRequest>()
           .StrictMode(true)
           .RuleFor(x => x.Id, (int?)null)
           .RuleFor(x => x.Name, f => f.Commerce.ProductName())
           .RuleFor(x => x.Description, f => f.Lorem.Sentence())
           .RuleFor(x => x.Images, f => new List<byte[]> { ImageMother.Create(f) })
           .RuleFor(x => x.Steps, stepList);

        return faker.Generate();
    }
}
