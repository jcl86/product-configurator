using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class ViolinFactory
    {
        private static InstrumentType Type = InstrumentType.Violin;

        public static Item Carbon => new Item()
        {
            Name = "Carbon fiber",
            Description = "Carbon fiber can be painted. It can also be left in an exposed carbon finish, so that the framework can be seen.Carbon look is widely used in Formula 1.",
            Price = 920m,
            Type = ItemType.Carbon,
            Images = new ItemImages(Type, "carbon.jpg")
        };
        public static Item Glass => new Item()
        {
            Name = "Glass fiber",
            Description = "Fiberglass is widely used in sports equipment. The basic fibreglass case is white or black (matte or glossy).",
            Price = 850m,
            Type = ItemType.Fiber,
            Images = new ItemImages(Type, "glass.jpg")
        };

        public static Item Plain => new Item()
        {
            Name = "Plain",
            Description = "Small squares carbon look pattern.",
            Price = 0m,
            Type = ItemType.None,
            Images = new ItemImages(Type, "plain.jpg")
        };
        public static Item Twill => new Item()
        {
            Name = "Twill",
            Description = "Herringbone carbon look pattern.",
            Price = 0m,
            Type = ItemType.None,
            Images = new ItemImages(Type, "twill.jpg")
        };

        public static Item Milk => new Item()
        {
            Name = "Milk",
            Description = "A smooth design for a sleek  look.",
            Price = 100m,
            Type = ItemType.Milk,
            Images = new ItemImages(Type, "milk-navy.png", "milk-orange.png", "milk-rosy.png", "milk-tile.png")
        };

        public static Item Diagonalink => new Item()
        {
            Name = "Diagonalink",
            Description = "An elegant twist on the DUPLO collection.",
            Price = 120m,
            Type = ItemType.Diagonalink,
            Images = new ItemImages(Type, "diagonalink-blue.png", "diagonalink-grey.png", "diagonalink-lemon.png",
                "diagonalink-rosy.png")
        };

        public static Item Duplo => new Item()
        {
            Name = "Duplo",
            Description = "A Bolder Version of the MILK collection for a a more exaggerated statement.",
            Price = 100m,
            Type = ItemType.Duplo,
            Images = new ItemImages(Type, "duplo-blue.png", "duplo-classic.png", "duplo-lemon.png", "duplo-pink.png",
                "duplo-red.png", "duplo-rosy.png")
        };

        public static Item Natural => new Item()
        {
            Name = "Natural",
            Description = "New fresh Handmade style.",
            Price = 0m,
            Type = ItemType.None,
            Images = new ItemImages(Type, "natural.jpg","glass.jpg")
        };

        public static Item BlackMatte => new Item()
        {
            Name = "Black matte",
            Description = "Matte black finish",
            Price = 0m,
            Images = new ItemImages(Type, "black-matte.jpg")
        };
        public static Item BlackGlossy => new Item()
        {
            Name = "Blackglossy",
            Description = "Glossy black finish.",
            Price = 0m,
            Images = new ItemImages(Type, "bright-black.jpg")
        };
        public static Item White => new Item()
        {
            Name = "White",
            Description = "This bright white paint is special. It is used on windmills to slow the deterioration caused by the continuous wear of the wind.",
            Price = 0m,
            Images = new ItemImages(Type, "white.jpg")
        };

        public static Item Bag => new Item()
        {
            Name = "Detachable bag",
            Description = "Textile bag for music scores and clothes.",
            Price = 0m,
            Images = new ItemImages(Type, "bag.jpg")
        };

        public static IEnumerable<Item> Materials => new List<Item>() { Carbon, Glass };
        public static IEnumerable<Item> Finish => new List<Item>() { Plain, Twill };
        public static IEnumerable<Item> Colors => new List<Item>() { BlackMatte, BlackGlossy, White };
        public static IEnumerable<Item> Designs => new List<Item>() { Milk, Diagonalink, Duplo, Natural };
        public static IEnumerable<Item> Accessories => new List<Item>() { Bag };

        public static IEnumerable<Item> DuploDesigns => new List<Item>() 
        { 
            DuploViolinFactory.Blue,
            DuploViolinFactory.Classic,
            DuploViolinFactory.Lemon,
            DuploViolinFactory.Pink,
            DuploViolinFactory.Red,
            DuploViolinFactory.Rosy,
        };

        public static IEnumerable<Item> MilkDesigns => new List<Item>()
        {
            MilkViolinFactory.Navy,
            MilkViolinFactory.Orange,
            MilkViolinFactory.Rosy,
            MilkViolinFactory.Tile
        };

        public static IEnumerable<Item> DiagonalinkDesigns => new List<Item>()
        {
            DiagonalinkViolinFactory.Navy,
            DiagonalinkViolinFactory.Orange,
            DiagonalinkViolinFactory.Rosy,
            DiagonalinkViolinFactory.Tile
        };
    }
}
