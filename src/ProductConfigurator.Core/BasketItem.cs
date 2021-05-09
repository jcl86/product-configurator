using System.Linq;

namespace ProductConfigurator.Core
{
    public class BasketItem
    {
        public Item Item { get; }
        public Step Step { get; }

        public BasketItem(Item item, Step step)
        {
            Item = item;
            Step = step;
        }
    }
}
