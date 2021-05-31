namespace ProductConfigurator.Core
{
    public static class ProductFactory
    {
        public static Product Accordion => new Product()
        {
            Id = 1,
            Name = "Accordion"
        };
        
        public static Product Violin => new Product()
        {
            Id = 2,
            Name = "Violin"
        }; 

        public static Product Cello => new Product()
        {
            Id = 3,
            Name = "Cello"
        };
    }
}
