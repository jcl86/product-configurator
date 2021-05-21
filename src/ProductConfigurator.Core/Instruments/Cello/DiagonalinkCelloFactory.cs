namespace ProductConfigurator.Core
{
    public class DiagonalinkCelloFactory
    {
        private static InstrumentType Type = InstrumentType.Cello;

        public static Item Grey => new Item()
        {
            Name = "Grey",
            Images = new ItemImages(Type, "diagonalink-grey.png")
        };

        public static Item Navy => new Item()
        {
            Name = "Navy",
            Images = new ItemImages(Type, "diagonalink-navy.png")
        };

        public static Item Rosy => new Item()
        {
            Name = "Rosy",
            Images = new ItemImages(Type, "diagonalink-rosy.png")
        };

        public static Item Yellow => new Item()
        {
            Name = "Yellow",
            Images = new ItemImages(Type, "diagonalink-yellow.png")
        };
    }
}
