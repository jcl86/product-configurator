using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class CelloFactory
    {
        public static Item Title => Item.Create("Eco linen Cello case", "Technological craftsmanship in a natural linen cello case that protects your instrument and your back forever.", 1160m);
        public static Item Linen => Item.Create("Natural linen", @"Linen is a surly looking fabric, like sackcloth.
We harden the fabric with the same process used to harden carbon fibre, until the surface is rigid.Its appearance is original, different, and homely.
The linen composite is used in high end designer furniture.", 1160m);

        public static Item Milk => Item.Create("Milk", "A smooth design for a sleek  look.", 100m); //RAL orange:2002, marine blue:5013, yellow:1021, pink: 4003
        public static Item Diagonalink => Item.Create("Diagonalink", "An elegant twist on the DUPLO collection.", 120m);//yellow, black, blue, rosie
        public static Item Duplo => Item.Create("Duplo", "A Bolder Version of the MILK collection for a a more exaggerated statement.", 100m);//blue, yellow, red, pink, nude, classic
        public static Item Natural => Item.Create("Natural", "New fresh Handmade style", 0m);

        public static IEnumerable<Item> Materials => new List<Item>() { Linen }; 
        public static IEnumerable<Item> Colors => new List<Item>() { Milk, Diagonalink, Duplo, Natural }; 
    }
}
