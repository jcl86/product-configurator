using System.Linq;

namespace ProductConfigurator.Domain
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
