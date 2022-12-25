using ProductConfigurator.Shared;

namespace ProductConfigurator.Blazor;

[Service]
public class MailRepository
{
    private readonly ApiClient client;

    public MailRepository(ApiClient client)
    {
        this.client = client;
    }

    public async Task<string> Ping()
    {
        return "";
        //var response = await client.Client.GetAsync(MailEndpoints.Ping);
        //response.EnsureSuccessStatusCode();
        //var result = await response.Content.ReadAsStringAsync();
        //return result;
    }
}
