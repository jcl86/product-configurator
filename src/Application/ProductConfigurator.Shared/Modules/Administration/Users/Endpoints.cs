namespace ProductConfigurator.Shared;

public static partial class Endpoints
{
    public static class Users
    {
        public const string Base = "api/users";

        public static string Get(string userId) => $"{Base}/{userId}";
        public static string GetAll = Base;
        public static string Register = $"{Base}/register";
        public static string Delete(string userId) => $"{Base}/{userId}";
    }
}
