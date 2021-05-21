namespace ProductConfigurator.Core
{
    public class MilkCelloFactory
    {
        private static InstrumentType Type = InstrumentType.Cello;

        public static Item Navy => new Item()
        {
            Name = "Navy",
            Images = new ItemImages(Type, "milk-navy.png")
        };

        public static Item Orange => new Item()
        {
            Name = "Orange",
            Images = new ItemImages(Type, "milk-orange.png")
        };

        public static Item Pink => new Item()
        {
            Name = "Pink",
            Images = new ItemImages(Type, "milk-pink.png")
        };

        public static Item Tile => new Item()
        {
            Name = "Tile",
            Images = new ItemImages(Type, "milk-tile.png")
        };
    }
}
