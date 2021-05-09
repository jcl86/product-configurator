using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class CelloFactory
    {
        public static Item Linen => Item.Create("Linen", "desc linen", 1000m);
        public static Item LinenNatural => Item.Create("Line natural", "desc linen", 1000m);

        public static Item Milk => Item.Create("Milk", "desc milk", 1m);
        public static Item Diagonalink => Item.Create("Diagonalink", "desc diagonalink", 1m);
        public static Item Duplo => Item.Create("Duplo", "desc duplo", 1m);
        public static Item NoColor => Item.Create("No color", "", 0m);

        public static IEnumerable<Item> Materials => new List<Item>() { Linen, LinenNatural }; 
        public static IEnumerable<Item> Colors => new List<Item>() { Milk, Diagonalink, Duplo, NoColor }; 
    }
}
