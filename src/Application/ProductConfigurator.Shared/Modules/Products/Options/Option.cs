using System.Collections.Generic;

namespace ProductConfigurator.Shared.Modules.Products.Options;

public class Option
{
    public int Id { get; set; }

    public const int MaxLengthName = 100;
    public string Name { get; set; }

    public decimal Price { get; set; }

    public const int MaxLengthDescription = 1000;
    public string Description { get; set; }

    public IEnumerable<string> Tags { get; set; }
    public IEnumerable<string> ImageUrls { get; set; }
}
