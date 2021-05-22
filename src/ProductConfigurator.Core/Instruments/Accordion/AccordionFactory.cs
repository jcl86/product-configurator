using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class AccordionFactory
    {
        private static InstrumentType Type = InstrumentType.Accordion;

        public static Item Button => new Item()
        {
            Name = "Button accordion",
            Description = "I have a button accordion.",
            Type = ItemType.Buttons,
            Images = new ItemImages(Type, "button.jpg")
        };

        public static Item Keyboard => new Item()
        {
            Name = "Keyboard accordion",
            Description = "I have a keyboard accordion.",
            Type = ItemType.Keyboard,
            Images = new ItemImages(Type, "keyboard.jpg")
        };

        public static Item ClassicEdition => new Item()
        {
            Name = "Classic edition case",
            Description = "Handmade fresh minimal design for everlasting accordion and back protection.",
            Price = 990m,
            Type = ItemType.ClassicEdition,
            Images = new ItemImages(Type, "classic-edition.jpg")
        };
        public static Item NewEdition => new Item()
        {
            Name = "New edition case",
            Description = "Lightweight and versatile. Place the instrument perfectly and close the case in 1 minute.",
            Price = 990m,
            Type = ItemType.NewEdition,
            Images = new ItemImages(Type, "new-edition.jpg")
        };

        public static Item WithCaps => new Item()
        {
            Name = "With caps",
            Description = "The accessory for carrying the accordion in two parts.",
            Price = 314m,
            Images = new ItemImages(Type, "caps.jpg", "intermediate-caps.jpg")
        };

        public static Item WithoutCaps => new Item()
        {
            Name = "Without caps",
            Description = "I don't divide the accordion.",
            Images = new ItemImages(Type, "no-caps.jpg")
        };

        public static Item Carbon => new Item()
        {
            Name = "Carbon fiber",
            Description = "Carbon fiber can be painted. It can also be left in an exposed carbon finish, so that the framework can be seen.Carbon look is widely used in Formula 1.",
            Price =  170m,
            Type = ItemType.Carbon,
            Images = new ItemImages(Type, "carbon.jpg")
        };
        public static Item Glass => new Item()
        {
            Name = "Glass fiber",
            Description = "Fiberglass is widely used in sports equipment. The basic fibreglass case is white or black (matte or glossy).",
            Type = ItemType.Fiber,
            Images = new ItemImages(Type, "glass.jpg")
        };

        public static Item Plain => new Item()
        {
            Name = "Plain",
            Description = "Small squares carbon look pattern",
            Images = new ItemImages(Type, "plain.png")
        };
        public static Item Twill => new Item()
        {
            Name = "Twill",
            Description = "Herringbone carbon look pattern.",
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
            Images = new ItemImages(Type, "diagonalink-classic.png", "diagonalink-lemon.png", "diagonalink-navy.png", "diagonalink-rosy.png")
        };

        public static Item Duplo => new Item()
        {
            Name = "Duplo",
            Description = "A Bolder Version of the MILK collection for a a more exaggerated statement.",
            Price = 100m,
            Type = ItemType.Duplo,
            Images = new ItemImages(Type, "duplo-classic.png", "duplo-red.png", "duplo-rosy.png", "duplo-yellow.png")
        };

        public static Item Natural => new Item()
        {
            Name = "Natural",
            Description = "Fresh Handmade style.",
            Images = new ItemImages(Type, "natural.jpg")
        };

        public static Item BlackMatte => new Item()
        {
            Name = "Black matte",
            Description = "Matte black finish.",
            Images = new ItemImages(Type, "black-matte.jpg")
        };

        public static Item BlackGlossy => new Item()
        {
            Name = "Black glossy",
            Description = "Glossy black finish.",
            Images = new ItemImages(Type, "bright-black.jpg")
        };

        public static Item White => new Item()
        {
            Name = "White",
            Description = "This bright white paint is special. It is used on windmills to slow the deterioration caused by the continuous wear of the wind.",
            Images = new ItemImages(Type, "white.jpg")
        };
        public static IEnumerable<Item> AccordionType => new List<Item>() { Button, Keyboard };
        public static IEnumerable<Item> CaseType => new List<Item>() { ClassicEdition, NewEdition };
        public static IEnumerable<Item> Caps => new List<Item>() { WithCaps, WithoutCaps };
        public static IEnumerable<Item> Materials => new List<Item>() { Carbon, Glass };
        public static IEnumerable<Item> Finish => new List<Item>() { Plain, Twill };
        public static IEnumerable<Item> Colors => new List<Item>() { BlackMatte, BlackGlossy, White };
        public static IEnumerable<Item> Designs => new List<Item>() { Milk, Diagonalink, Duplo, Natural };


        public static Item ExtraHandle => new Item()
        {
            Name = "Extra handle for the right hand manual.",
            Description = "",
            Price = 10m,
            Images = new ItemImages(Type)
        };

        public static Item ExtraCushion => new Item()
        {
            Name = "Extra cushion",
            Description = "One more adaptable cushion.",
            Price = 10m,
            Images = new ItemImages(Type, "extra-cushion.png")
        };

        public static Item InnerPocket => new Item()
        {
            Name = "Inner pocket",
            Description = "Detachable pocket for music scores and accordion straps.",
            Price = 20m,
            Images = new ItemImages(Type, "extra-pockets.jpg")
        };
        public static Item Wheels => new Item()
        {
            Name = "Wheels",
            Description = "Industrial stainless steel small wheels to free you while waiting in a queue. You can place the case on the floor, and advance without having to bend down, only pushing gently the case.",
            Price = 99m,
            Images = new ItemImages(Type, "wheels.jpg")
        };

        public static Item Waistbelt => new Item()
        {
            Name = "Waistbelt",
            Description = "Ergonomic fully adaptable fastening for releasing 5 kg of the accordion weight from your shoulders.",
            Price = 48m,
            Images = new ItemImages(Type, "waistbelt.jpg")
        };

        public static IEnumerable<Item> Accesories => new List<Item>() { ExtraHandle, ExtraCushion, InnerPocket, Wheels, Waistbelt };

        public static IEnumerable<Item> DuploDesigns => new List<Item>()
        {
            DuploAccordionFactory.Yellow,
            DuploAccordionFactory.Classic,
            DuploAccordionFactory.Red,
            DuploAccordionFactory.Rosy,
        };

        public static IEnumerable<Item> MilkDesigns => new List<Item>()
        {
            MilkAccordionFactory.Navy,
            MilkAccordionFactory.Orange,
            MilkAccordionFactory.Rosy,
            MilkAccordionFactory.Tile
        };

        public static IEnumerable<Item> DiagonalinkDesigns => new List<Item>()
        {
            MilkAccordionFactory.Navy,
            MilkAccordionFactory.Orange,
            MilkAccordionFactory.Rosy,
            MilkAccordionFactory.Tile
        };
    }
}
