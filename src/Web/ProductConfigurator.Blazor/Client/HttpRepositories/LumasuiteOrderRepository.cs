using System.Net.Http.Json;
using System.Threading.Tasks;
using ProductConfigurator.Domain;
using ProductConfigurator.Shared;

namespace ProductConfigurator.Blazor;

[Service]
public class LumasuiteOrderRepository
{
    private readonly ApiClient client;

    public LumasuiteOrderRepository(ApiClient client)
    {
        this.client = client;
    }

    public async Task SendMail()
    {
        //var response = await client.Client.PostAsJsonAsync(LumasuiteOrderEndpoints.Post, dto);
        //response.EnsureSuccessStatusCode();
    }

}
