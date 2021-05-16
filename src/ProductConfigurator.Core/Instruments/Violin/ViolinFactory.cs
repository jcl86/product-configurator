using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class ViolinFactory
    {
        public static Item Carbon => Item.Create("Carbon fiber", 
            "Carbon fiber can be painted. It can also be left in an exposed carbon finish, so that the framework can be seen.Carbon look is widely used in Formula 1.", 
            920m, 
            ItemType.Carbon);
        public static Item Glass => Item.Create("Glass fiber", 
            "Fiberglass is widely used in sports equipment. The basic fibreglass case is white or black (matte or glossy).",
            850m, ItemType.Fiber, 
            "glass.jpg");

        public static Item Plain => Item.Create("Plain", "Small squares carbon look pattern.", 
            0m, ItemType.None,
            "plain.jpg");
        public static Item Twill => Item.Create("Twill", "Herringbone carbon look pattern.", 
            0m, ItemType.None,
            "twill.jpg");

        public static Item Milk => Item.Create("Milk", "A smooth design for a sleek  look.", 100m); //RAL orange:2002, marine blue:5013, yellow:1021, pink: 4003
        public static Item Diagonalink => Item.Create("Diagonalink", "An elegant twist on the DUPLO collection.", 120m);//yellow, black, blue, rosie
        public static Item Duplo => Item.Create("Duplo", "A Bolder Version of the MILK collection for a a more exaggerated statement.", 100m);//blue, yellow, red, pink, nude, classic
        public static Item Natural => Item.Create("Natural", "New fresh Handmade style.", 0m);

        public static Item BlackMatte => Item.Create("Blackmatte", "Matte black finish.", 0m);
        public static Item BlackGlossy => Item.Create("Blackglossy", "Glossy black finish.", 0m);
        public static Item White => Item.Create("White", 
            "This bright white paint is special. It is used on windmills to slow the deterioration caused by the continuous wear of the wind.",
            0m, ItemType.None, "white.jpg");

        public static Item Bag => Item.Create("Detachable bag", "Textile bag for music scores and clothes.", 0m);

        public static IEnumerable<Item> Materials => new List<Item>() { Carbon, Glass };
        public static IEnumerable<Item> Finish => new List<Item>() { Plain, Twill };
        public static IEnumerable<Item> Colors => new List<Item>() { BlackMatte, BlackGlossy, White };
        public static IEnumerable<Item> Designs => new List<Item>() { Milk, Diagonalink, Duplo, Natural };
        public static IEnumerable<Item> Accessories => new List<Item>() { Bag };
    }
}
