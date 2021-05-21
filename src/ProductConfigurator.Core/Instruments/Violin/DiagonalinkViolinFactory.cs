namespace ProductConfigurator.Core
{
    public class DiagonalinkViolinFactory
    {
        private static InstrumentType Type = InstrumentType.Violin;

        public static Item Navy => new Item()
        {
            Name = "Blue",
            Images = new ItemImages(Type, "diagonalink-blue.png")
        };

        public static Item Orange => new Item()
        {
            Name = "Grey",
            Images = new ItemImages(Type, "diagonalink-grey.png")
        };

        public static Item Rosy => new Item()
        {
            Name = "Lemon",
            Images = new ItemImages(Type, "diagonalink-lemon.png")
        };

        public static Item Tile => new Item()
        {
            Name = "Rosy",
            Images = new ItemImages(Type, "diagonalink-rosy.png")
        };
    }
}
