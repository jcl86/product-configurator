namespace ProductConfigurator.Shared.Modules.Catalog.Products;
public class GetAllFromShopResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required IEnumerable<string> PhotoUrls { get; set; }
    public int TotalSteps { get; set; }
}
