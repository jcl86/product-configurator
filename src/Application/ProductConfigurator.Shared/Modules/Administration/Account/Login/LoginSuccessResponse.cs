using ProductConfigurator.Shared.Modules.Administration.Users;

using System;
using System.Security.Claims;

namespace ProductConfigurator.Shared.Modules.Administration.Account;

public class LoginSuccessResponse
{
    public string Email { get; init; }
    public string Token { get; init; }
    public LoginSuccessResponse(string email, string token)
    {
        Email = email;
        Token = token;
    }
}