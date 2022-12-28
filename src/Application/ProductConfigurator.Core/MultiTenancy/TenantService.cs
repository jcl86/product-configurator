namespace ProductConfigurator.Core.MultiTenancy;

public class TenantService : ITenantProvider
{
    public string? CurrentTenant { get; private set; }
    
    public static readonly IEnumerable<string> All = new[] { "c1", "c2" };

    public void SetTenant(string? value)
    {
        var companyCode = All.FirstOrDefault(t => t.Equals(value?.Trim(), StringComparison.InvariantCultureIgnoreCase));
        if (companyCode is null)
        {
            throw new ArgumentException($"Company {value ?? ""} is not supported");
        }
        CurrentTenant = companyCode;
    }
}