using System.Collections.Generic;
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
    }
}
