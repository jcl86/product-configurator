namespace ProductConfigurator.Core
{
    public class DuploViolinFactory
    {
        private static InstrumentType Type = InstrumentType.Violin;

        public static Item Blue => new Item()
        {
            Name = "Blue",
            Images = new ItemImages(Type, "duplo-blue.png")
        };

        public static Item Classic => new Item()
        {
            Name = "Classic",
            Images = new ItemImages(Type, "duplo-classic.png")
        };

        public static Item Lemon => new Item()
        {
            Name = "Lemon",
            Images = new ItemImages(Type, "duplo-lemon.png")
        };

        public static Item Pink => new Item()
        {
            Name = "Pink",
            Images = new ItemImages(Type, "duplo-pink.png")
        };

        public static Item Red => new Item()
        {
            Name = "Red",
            Images = new ItemImages(Type, "duplo-red.png")
        };

        public static Item Rosy => new Item()
        {
            Name = "Rosy",
            Images = new ItemImages(Type, "duplo-rosy.png")
        };
    }
}
