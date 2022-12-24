using System.ComponentModel.DataAnnotations;

namespace ProductConfigurator.Shared.Modules.Administration.Account;

public class LoginRequest
{
    public string Email { get; init; }

    public string Password { get; init; }
    
    public LoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
