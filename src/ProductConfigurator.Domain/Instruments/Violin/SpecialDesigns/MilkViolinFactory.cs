namespace ProductConfigurator.Domain
{
    public class MilkViolinFactory
    {
        private static InstrumentType Type = InstrumentType.Violin;

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

        public static Item Rosy => new Item()
        {
            Name = "Rosy",
            Images = new ItemImages(Type, "milk-rosy.png")
        };

        public static Item Tile => new Item()
        {
            Name = "Tile",
            Images = new ItemImages(Type, "milk-tile.png")
        };
    }
}
