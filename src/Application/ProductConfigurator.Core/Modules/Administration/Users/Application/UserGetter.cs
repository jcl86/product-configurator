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
        return new GetUserResponse(id: user.Id, email: user.Email ?? "", roles: user.RoleNames);
    }
}

