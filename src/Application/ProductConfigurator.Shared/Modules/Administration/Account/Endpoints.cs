namespace ProductConfigurator.Shared;

public static partial class Endpoints
{
    public static class Accounts
    {
        public const string Base = "api/accounts";

        public static readonly string Login = $"{Base}/login";
        public static readonly string ChangePassword = $"{Base}/change-password";
        public static readonly string ResetPassword = $"{Base}/reset-password";
    }
}
