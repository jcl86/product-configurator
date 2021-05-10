using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class ViolinFactory
    {
        public static Item Carbon => Item.Create("Carbon fiber", "desc carb", 1200m, ItemType.Carbon);
        public static Item Glass => Item.Create("Glass fiber", "desc glass", 1000m, ItemType.Fiber);

        public static Item Plain => Item.Create("Plain", "desc carb", 1200m);
        public static Item Twirl => Item.Create("Twirl", "desc glass", 1000m);

        public static Item Milk => Item.Create("Milk", "desc milk", 1m);
        public static Item Diagonalink => Item.Create("Diagonalink", "desc diagonalink", 1m);
        public static Item Duplo => Item.Create("Duplo", "desc duplo", 1m);
        public static Item NoColor => Item.Create("No color", "", 0m);

        public static Item Black => Item.Create("Black", "", 0m);
        public static Item White => Item.Create("White", "", 0m);

        public static IEnumerable<Item> Materials => new List<Item>() { Carbon, Glass };
        public static IEnumerable<Item> Design => new List<Item>() { Plain, Twirl };
        public static IEnumerable<Item> Colors => new List<Item>() { Black, White };
        public static IEnumerable<Item> ExtraColors => new List<Item>() { Milk, Diagonalink, Duplo, NoColor };
    }
}
