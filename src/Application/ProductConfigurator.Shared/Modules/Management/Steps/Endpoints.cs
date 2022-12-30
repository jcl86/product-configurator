namespace ProductConfigurator.Shared;

public static partial class Endpoints
{
    public static class Steps
    {
        public const string Base = "api/steps";

        public static string PutSteps(int productId) => $"api/products/{productId}/steps";
        public static string Delete(string stepId) => $"{Base}/{stepId}";
    }
}