using ProductConfigurator.Shared.Modules.Administration;
using ProductConfigurator.Shared.Modules.Management.Steps;

namespace ProductConfigurator.Shared.Modules.Catalog.Products;

public class GetProductResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required IEnumerable<string> PhotoUrls { get; set; }
    public required IEnumerable<Step> Steps { get; set; }

    public class Step
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public ChoiceType ChoiceType { get; set; }
        public required string Name { get; set; }
        public required IEnumerable<Option> Options { get; set; }
    }

    public class Option
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public required IEnumerable<string> Tags { get; set; }
    }
}