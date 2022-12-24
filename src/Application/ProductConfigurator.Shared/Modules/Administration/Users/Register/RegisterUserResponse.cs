namespace ProductConfigurator.Shared.Modules.Administration.Users;

public class RegisterUserResponse
{
    public string Id { get; init; }
    public string Email { get; init; }

    public RegisterUserResponse(string id, string email)
    {
        Id = id;
        Email = email;
    }
}