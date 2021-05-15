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
        public decimal TotalWithoutVat() => items.Sum(x => x.Item.Price);
        public decimal Vat() => TotalWithoutVat() * 0.21m;
        public decimal Total() => TotalWithoutVat() + Vat();

        public IEnumerable<BasketGroupItem> Basket => items
            .GroupBy(x => x.Step)
            .Select(x => new BasketGroupItem(x.Key, x.Select(i => i.Item)))
            .ToList();

        public bool WasClasicEditionChoosen()
        {
            return items.Any(x => x.Item.IsClassicEdition);
        }

        public bool CanLastBeRemoved() => items.Any();

        public Step? RemoveLast()
        {
            if (!items.Any())
            {
                return null;
            }

            var item = items.Last();
            items.Remove(item);
            return item.Step;

        }
    }
}
