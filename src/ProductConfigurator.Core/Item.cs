using System.Collections.Generic;
using System.Linq;

namespace ProductConfigurator.Core
{
    public class Item
    {
        public bool HasMoreThanOneImage => images.Count() > 1;
        public int Images => images.Count();
        private readonly string[] images;
        public string Image(InstrumentType type)
        {
            if (!images.Any())
            {
                return Constants.DefaultImage;
            }
            return images.Select(x => $"img/{type.ToString().ToLower()}/{x}").ElementAt(currentImageIndex);
        }

        public bool IsFirst() => currentImageIndex == 0;        
        public void NextImage()
        {
            if (!IsLast())
            {
                currentImageIndex++;
            }
        }

        public bool IsLast() => currentImageIndex >= images.Count() - 1;
        public void PreviousImage()
        {
            if (!IsFirst())
            {
                currentImageIndex--;
            }
        }

        private int currentImageIndex;
        public bool IsIndex(int index) => currentImageIndex == index;

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
            currentImageIndex = 0;
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
