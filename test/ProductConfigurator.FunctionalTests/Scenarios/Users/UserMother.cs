using Bogus;

using ProductConfigurator.Shared.Modules.Administration.Users;

namespace ProductConfigurator.FunctionalTests;

public class UserMother
{
    public static RegisterUserRequest Register(string? password = null)
    {
        var faker = new Faker<RegisterUserRequest>()
           .StrictMode(true)
           .RuleFor(x => x.Email, f => f.Person.Email)
           .RuleFor(x => x.Password, f => password is null ? PasswordMother.Valid() : password);

        return faker.Generate();
    }
}
