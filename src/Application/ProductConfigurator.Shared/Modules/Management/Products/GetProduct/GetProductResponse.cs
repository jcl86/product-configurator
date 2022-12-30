using ProductConfigurator.Shared.Modules.Administration;
using ProductConfigurator.Shared.Modules.Management.Steps;

namespace ProductConfigurator.Shared.Modules.Management.Products;

public class GetProductResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public required IEnumerable<byte[]> Images { get; set; }
    public required IEnumerable<Step> Steps { get; set; }

    public class Step
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Order { get; set; }
    }
}