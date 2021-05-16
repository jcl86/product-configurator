using System.Collections.Generic;
using System.Linq;

namespace ProductConfigurator.Core
{
    public class Item
    {
        private readonly string[] images;
        public IEnumerable<string> Images(InstrumentType type)
        {
            if (!images.Any())
            {
                return new string[] { Constants.DefaultImage };
            }
            return images.Select(x => $"img/{type.ToString().ToLower()}/{x}");
        }

        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string PriceText => $"{Price:C}";

        public ItemType Type { get; }

        private Item(string name, string description, decimal price, ItemType type, params string[] images)
        {
            Name = name;
            Description = description;
            Price = price;
            Type = type;
            this.images = images;
        }

        public static Item Create(string name, string description, decimal price,
            ItemType type = ItemType.None,
            params string[] images)
            => new Item(name, description, price, type, images);

        public bool IsCarbon => Type == ItemType.Carbon;
        public bool IsFiber => Type == ItemType.Fiber;
        public bool IsClassicEdition => Type == ItemType.ClassicEdition;
        public bool IsNewEdition => Type == ItemType.NewEdition;
        public bool IsPiano => Type == ItemType.Keyboard;
        public bool IsButton => Type == ItemType.Buttons;
    }
}
