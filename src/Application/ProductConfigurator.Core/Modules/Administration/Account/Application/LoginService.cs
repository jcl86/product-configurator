using Microsoft.AspNetCore.Identity;
using ProductConfigurator.Shared;
using ProductConfigurator.Shared.Modules.Administration.Account;

using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Core.Modules.Administration.Account.Infrastructure;

namespace ProductConfigurator.Core.Modules.Administration.Account;

[Service]
public class LoginService
{
    public const string LoginError = "Incorrect user or password";
    public const string AccountLockedOut = "The account is locked out";
    
    private readonly UserFinder userFinder;
    private readonly UserManager<User> userManager;
    private readonly TokenGenerator tokenGenerator;

    public LoginService(UserFinder userFinder, 
        UserManager<User> userManager, 
        TokenGenerator tokenGenerator)
    {
        this.userFinder = userFinder;
        this.userManager = userManager;
        this.tokenGenerator = tokenGenerator;
    }

    public async Task<string> GetAuthenticationToken(LoginRequest model)
    {
        User user = await userFinder.FindByEmail(model.Email);

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
        return token;
    }
}
