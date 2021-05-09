using System.Linq;

namespace ProductConfigurator.Core
{
    public class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        private Item(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public static Item Create(string name, string description, decimal price) => new Item(name, description, price);
    }
}
