using System.Globalization;

namespace ProductConfigurator.Domain
{
    public class Item
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public string PriceText => Price.ToString("C", new CultureInfo("es-ES"));

        public int Maximun { get; init; }

        public ItemType Type { get; init; } = ItemType.None;

        public ItemImages Images { get; init; }

        public bool IsCarbon => Type == ItemType.Carbon;
        public bool IsFiber => Type == ItemType.Fiber;
        public bool IsClassicEdition => Type == ItemType.ClassicEdition;
        public bool IsNewEdition => Type == ItemType.NewEdition;
        public bool IsPiano => Type == ItemType.Keyboard;
        public bool IsButton => Type == ItemType.Buttons;
        public bool IsSpecialDesign => Type == ItemType.Duplo || Type == ItemType.Milk || Type == ItemType.Diagonalink;
    }
}
