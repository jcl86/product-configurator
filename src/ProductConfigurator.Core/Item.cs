using System.Linq;

namespace ProductConfigurator.Core
{
    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string PriceText => $"{Price:C}";

        public ItemType Type { get; }

        private Item(string name, string description, decimal price, ItemType type)
        {
            Name = name;
            Description = description;
            Price = price;
            Type = type;
        }

        public static Item Create(string name, string description, decimal price, ItemType type = ItemType.None) 
            => new Item(name, description, price, type);

        public bool IsCarbon => Type == ItemType.Carbon;
        public bool IsFiber => Type == ItemType.Fiber;
        public bool IsClassicEdition => Type == ItemType.ClassicEdition;
        public bool IsNewEdition => Type == ItemType.NewEdition;
        public bool IsPiano => Type == ItemType.Piano;
        public bool IsButton => Type == ItemType.Buttons;
    }
}
