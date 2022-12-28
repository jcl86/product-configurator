using System.ComponentModel.DataAnnotations;

namespace ProductConfigurator.Shared.Modules.Administration.Account;

public class LoginRequest
{
    public required string Email { get; set; }
    
    public required string Password { get; set; }
}
