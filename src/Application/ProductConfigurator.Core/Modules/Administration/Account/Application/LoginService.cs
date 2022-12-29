using Microsoft.AspNetCore.Identity;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Account;

using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Core.Modules.Administration.Account.Infrastructure;
using ProductConfigurator.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace ProductConfigurator.Core.Modules.Administration.Account;

[Service]
public class LoginService
{
    public const string LoginError = "Incorrect user or password";
    public const string AccountLockedOut = "The account is locked out";
    
    private readonly ApplicationContext context;
    private readonly UserManager<User> userManager;
    private readonly TokenGenerator tokenGenerator;

    public LoginService(ApplicationContext context, 
        UserManager<User> userManager, 
        TokenGenerator tokenGenerator)
    {
        this.context = context;
        this.userManager = userManager;
        this.tokenGenerator = tokenGenerator;
    }

    public async Task<LoginSuccessResponse> GetAuthenticationToken(LoginRequest model)
    {
        User? user = await context.Users
            .Include(x => x.Claims)
            .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
            .IgnoreQueryFilters()
            .SingleOrDefaultAsync(x => x.Email == model.Email);

        if (user is null)
        {
            throw new UnauthorizedAccessException(LoginError);
        }

        if (userManager.SupportsUserLockout && await userManager.IsLockedOutAsync(user))
        {
            throw new UnauthorizedAccessException(AccountLockedOut);
        }

        bool succeded = await userManager.CheckPasswordAsync(user, model.Password);
        if (!succeded)
        {
            throw new UnauthorizedAccessException(LoginError);
        }

        string token = tokenGenerator.GenerateToken(user);

        return new LoginSuccessResponse()
        {
            Email = model.Email,
            Token = token,
            TenantId = user.TenantId
        };
    }
}
