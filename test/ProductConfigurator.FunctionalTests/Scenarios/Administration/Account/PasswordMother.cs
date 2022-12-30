namespace ProductConfigurator.FunctionalTests.Scenarios.Administration.Account;

public static class PasswordMother
{
    public static string Valid() => Guid.NewGuid().ToString() + "*aA";
    public static string Weak() => "abcd";
}
