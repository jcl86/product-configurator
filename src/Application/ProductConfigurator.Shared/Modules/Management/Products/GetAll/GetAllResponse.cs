namespace ProductConfigurator.Shared.Modules.Management.Products;
public class GetAllResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required IEnumerable<string> PhotoUrls { get; set; }

    public int TotalSteps { get; set; }
}
