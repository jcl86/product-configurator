using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProductConfigurator.Core
{
    public class BasketGroupItem
    {
        public Step Step { get; }
        public IEnumerable<Item> Items { get; }

        public BasketGroupItem(Step step, IEnumerable<Item> items)
        {
            Step = step;
            Items = items;
        }

        public decimal Price => Items.Sum(x => x.Price);

        public string PriceText()
        {
            if (Price <= 0)
            {
                return "";
            }
            return Price.ToString("C", new CultureInfo("es-ES"));
        }

        public string ItemsText() => string.Join(", ", Items.Select(x => x.Name));
    }
}
