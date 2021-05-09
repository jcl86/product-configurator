using System.Collections.Generic;
using System.Linq;

namespace ProductConfigurator.Core
{
    public class ItemCollection
    {
        private readonly List<BasketItem> items;

        public ItemCollection()
        {
            items = new List<BasketItem>();
        }

        public void Add(Item item, Step step) => items.Add(new BasketItem(item, step));
        public decimal Total() => items.Sum(x => x.Item.Price);

        public IEnumerable<BasketGroupItem> Basket => items
            .GroupBy(x => x.Step)
            .Select(x => new BasketGroupItem(x.Key, x.Select(i => i.Item)))
            .ToList();
    }
}
