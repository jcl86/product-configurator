namespace ProductConfigurator.Core
{
    public static class DiagonalinkAccordionFactory
    {
        private static InstrumentType Type = InstrumentType.Accordion;

        public static Item Classic => new Item()
        {
            Name = "Classic",
            Images = new ItemImages(Type, "diagonalink-classic.png")
        };

        public static Item Lemon => new Item()
        {
            Name = "Lemon",
            Images = new ItemImages(Type, "diagonalink-lemon.png")
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
    }
}
