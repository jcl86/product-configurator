namespace ProductConfigurator.Shared
{
    public class Product
    {
        public const int NameMaxLength = 100;
        public const int PhotoUrlMaxLength = 250;

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public Tenant Tenant { get; set; }

        public int TotalSteps { get; set; }
    }
}
