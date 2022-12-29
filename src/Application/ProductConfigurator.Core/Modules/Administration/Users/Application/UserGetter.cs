using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Users;

namespace ProductConfigurator.Core.Modules.Administration.Users;

[Service]
public class UserGetter
{
    private readonly UserFinder finder;

    public UserGetter(UserFinder finder)
    {
        this.finder = finder;
    }
    
    public async Task<GetUserResponse> Get(string userId)
    {
        User user = await finder.Find(userId);
        return new()
        {
            Id = user.Id,
            Email = user.Email ?? "",
            Roles = user.RoleNames,
            TenantId = user.TenantId
        };

    }
}

