using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class CelloFactory
    {
        private static InstrumentType Type = InstrumentType.Cello;

        public static Item Title => new Item()
        {
            Name = "Eco linen Cello case",
            Description = "Technological craftsmanship in a natural linen cello case that protects your instrument and your back forever."
        };

        public static Item Linen => new Item()
        {
            Name = "Natural linen",
            Description = "Linen is a surly looking fabric, like sackcloth. We harden the fabric with the same process used to harden carbon fibre, until the surface is rigid.Its appearance is original, different, and homely. The linen composite is used in high end designer furniture.",
            Price = 1160m,
            Images = new ItemImages(Type, "case-front.jpg", "case-back.jpg", "case-opened.jpg")
        };

        public static Item Milk => new Item()
        {
            Name = "Milk",
            Description = "A smooth design for a sleek  look.",
            Price = 100m,
            Type = ItemType.Milk,
            Images = new ItemImages(Type, "milk-navy.png", "milk-orange.png", "milk-pink.png", "milk-tile.png")
        };

        public static Item Duplo => new Item()
        {
            Name = "Duplo",
            Description = "A Bolder Version of the MILK collection for a a more exaggerated statement.",
            Price = 100m,
            Type = ItemType.Duplo,
            Images = new ItemImages(Type, "duplo-blue.png", "duplo-classic.png", "duplo-lemon.png", "duplo-red.png", 
            "duplo-rosie.png", "duplo-rosy.png")
        };

        public static Item Diagonalink => new Item()
        {
            Name = "Diagonalink",
            Description = "An elegant twist on the DUPLO collection.",
            Price = 120m,
            Type = ItemType.Diagonalink,
            Images = new ItemImages(Type, "diagonalink-grey.png", "diagonalink-navy.png", 
            "diagonalink-rosy.png", "diagonalink-yellow.png")
        };

        public static Item Natural => new Item()
        {
            Name = "Natural",
            Description = "New fresh Handmade style",
            Images = new ItemImages(Type, "case-front.jpg")
        };
        public static IEnumerable<Item> Materials => new List<Item>() { Linen }; 
        public static IEnumerable<Item> Designs => new List<Item>() { Milk, Duplo, Diagonalink, Natural }; 
        public static IEnumerable<Item> DuploDesigns => new List<Item>()
        { 
            DuploCelloFactory.Blue,
            DuploCelloFactory.Classic,
            DuploCelloFactory.Lemon,
            DuploCelloFactory.Red,
            DuploCelloFactory.Rosie,
            DuploCelloFactory.Rosy,
        };

        public static IEnumerable<Item> MilkDesigns => new List<Item>()
        {
            MilkCelloFactory.Navy,
            MilkCelloFactory.Orange,
            MilkCelloFactory.Pink,
            MilkCelloFactory.Tile
        };

        public static IEnumerable<Item> DiagonalinkDesigns => new List<Item>()
        {
            DiagonalinkCelloFactory.Grey,
            DiagonalinkCelloFactory.Navy,
            DiagonalinkCelloFactory.Rosy,
            DiagonalinkCelloFactory.Yellow
        };
    }
}
