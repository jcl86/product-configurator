namespace ProductConfigurator.Domain
{
    public static class DuploAccordionFactory
    {
        private static InstrumentType Type = InstrumentType.Accordion;

        public static Item Classic => new Item()
        {
            Name = "Classic",
            Images = new ItemImages(Type, "duplo-classic.png")
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

        public static Item Yellow => new Item()
        {
            Name = "Yellow",
            Images = new ItemImages(Type, "duplo-yellow.png")
        };
    }
}
