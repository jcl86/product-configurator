using ProductConfigurator.Shared.Modules.Administration.Users;

using System;
using System.Security.Claims;

namespace ProductConfigurator.Shared.Modules.Administration.Account;

public class LoginSuccessResponse
{
    public required string Email { get; set; }
    public required string Token { get; set; }
    public int? ShopId { get; set; }
}