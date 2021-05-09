using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class CelloFactory
    {
        public static Item Linen => Item.Create("Linen", "desc linen", 1m);
        public static Item LinenNatural => Item.Create("Line natural", "desc linen", 1m);

        public static Item Milk => Item.Create("Milk", "desc milk", 1m);
        public static Item Diagonalink => Item.Create("Diagonalink", "desc diagonalink", 1m);
        public static Item Duplo => Item.Create("Duplo", "desc duplo", 1m);
        public static Item NoColor => Item.Create("No color", "", 0m);
        
        public static Item ExtraAside => Item.Create("Extra aside", "desc extra asife", 1m);
        public static Item Cushionextra => Item.Create("Extra cushion", "desc extra cush", 1m);

        public static IEnumerable<Item> CelloMaterials => new List<Item>() { Linen, LinenNatural }; 
        public static IEnumerable<Item> CelloColors => new List<Item>() { Milk, Diagonalink, Duplo, NoColor }; 

        public static IEnumerable<Item> CelloAccesories => new List<Item>() { ExtraAside, Cushionextra }; 
    }
}
