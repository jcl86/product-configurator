using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class AccordionFactory
    {              
        public static Item Button => Item.Create("Button accordion", 
            "I have a button accordion.", 
            0m, 
            ItemType.Buttons,
            "buttons.jpg");
        public static Item Keyboard => Item.Create("Keyboard accordion", 
            "I have a keyboard accordion.", 
            0m, 
            ItemType.Keyboard,
            "keyboard.jpg");

        public static Item ClassicEdition => Item.Create("Classic edition case", 
            "Handmade fresh minimal design for everlasting accordion and back protection.", 
            990m, 
            ItemType.ClassicEdition, 
            "classic-edition.jpg");
        public static Item NewEdition => Item.Create("New edition case", 
            "Lightweight and versatile. Place the instrument perfectly and close the case in 1 minute. ", 
            990m, 
            ItemType.NewEdition,
            "new-edition.jpg");

        public static Item WithCaps => Item.Create("With caps", 
            "The accessory for carrying the accordion in two parts.", 
            314m,
            ItemType.None,
            "caps.jpg");
        public static Item WithoutCaps => Item.Create("Without caps", 
            "I don't divide the accordion.", 
            0m,
            ItemType.None,
            "no-caps.jpg");

        public static Item Carbon => Item.Create("Carbon fiber", 
            "Carbon fiber can be painted. It can also be left in an exposed carbon finish, so that the framework can be seen.Carbon look is widely used in Formula 1.",
            170m, 
            ItemType.Carbon,
            "carbon.jpg");
        public static Item Glass => Item.Create("Glass fiber", 
            "Fiberglass is widely used in sports equipment. The basic fibreglass case is white or black (matte or glossy).",
            0m, 
            ItemType.Fiber,
            "glass.jpg");

        public static Item Plain => Item.Create("Plain", 
            "Small squares carbon look pattern.", 
            0m,
            ItemType.None,
            "plain.jpg");
        public static Item Twill => Item.Create("Twill", 
            "Herringbone carbon look pattern.",
            0m,
            ItemType.None,
            "twill.jpg");

        public static Item Milk => Item.Create("Milk", 
            "A smooth design for a sleek  look.", 
            100m); //RAL orange:2002, marine blue:5013, yellow:1021, pink: 4003
        public static Item Diagonalink => Item.Create("Diagonalink", 
            "An elegant twist on the DUPLO collection.", 
            120m);//yellow, black, blue, rosie
        public static Item Duplo => Item.Create("Duplo", 
            "A Bolder Version of the MILK collection for a a more exaggerated statement.", 
            100m);//blue, yellow, red, pink, nude, classic
        public static Item Natural => Item.Create("Natural", 
            "Fresh Handmade style.", 
            0m);

        public static Item BlackMatte => Item.Create("Black matte", 
            "Matte black finish.", 0m,
            ItemType.None,
            "black-matte.jpg");
        public static Item BlackGlossy => Item.Create("Black glossy", 
            "Glossy black finish.", 0m);
        public static Item White => Item.Create("White", 
            "This bright white paint is special. It is used on windmills to slow the deterioration caused by the continuous wear of the wind.", 
            0m);

        public static IEnumerable<Item> AccordionType => new List<Item>() { Button, Keyboard };
        public static IEnumerable<Item> CaseType => new List<Item>() { ClassicEdition, NewEdition };
        public static IEnumerable<Item> Caps => new List<Item>() { WithCaps, WithoutCaps };
        public static IEnumerable<Item> Materials => new List<Item>() { Carbon, Glass };
        public static IEnumerable<Item> Finish => new List<Item>() { Plain, Twill, BlackMatte, BlackGlossy, White };
        public static IEnumerable<Item> Colors => new List<Item>() { BlackMatte, BlackGlossy, White };
        public static IEnumerable<Item> Designs => new List<Item>() { Milk, Diagonalink, Duplo, Natural };

        public static Item ExtraHandle => Item.Create("Extra handle", 
            "Extra handle for the right hand manual.", 
            10m,
            ItemType.None);
        public static Item ExtraCushion => Item.Create("Extra cushion", 
            "One more adaptable cushion.", 
            10m, ItemType.None,
            "extra-cushion.png");
        public static Item InnerPocket => Item.Create("Inner pocket", "Detachable pocket for music scores and accordion straps.", 20m);
        public static Item Wheels => Item.Create("Wheels", 
            "Industrial stainless steel small wheels to free you while waiting in a queue. You can place the case on the floor, and advance without having to bend down, only pushing gently the case.", 
            99m,
            ItemType.None,
            "wheels.jpg");
        public static Item Waistbelt => Item.Create("Waistbelt", 
            "Ergonomic fully adaptable fastening for releasing 5 kg of the accordion weight from your shoulders.", 
            48m,
            ItemType.None,
            "waistbelt.jpg");

        public static IEnumerable<Item> Accesories => new List<Item>() { ExtraHandle, ExtraCushion, InnerPocket, Wheels, Waistbelt };
    }
}
