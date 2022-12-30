namespace ProductConfigurator.Shared;

public static partial class Endpoints
{
    public static class Products
    {
        public const string Base = "api/products";

        public static string Get(int productId) => $"{Base}/{productId}";
        public static string GetAllFromTenant(int tenantId) => $"api/tenants/{tenantId}/products";
        public static string PutSave = Base;
        public static string Delete(string productId) => $"{Base}/{productId}";
    }
}