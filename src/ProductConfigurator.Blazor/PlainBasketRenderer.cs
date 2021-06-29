using ProductConfigurator.Core;
using System;
using System.Linq;

namespace ProductConfigurator.Blazor
{
    public class PlainBasketRenderer
    {
        private readonly ItemCollection collection;

        public PlainBasketRenderer(ItemCollection collection)
        {
            this.collection = collection;
        }

        public string Render()
        {
            var basket = string.Join("", collection.Basket.Select(x => RenderBasketGroup(x)));
            return  $"Hello\n\n" +
                    $"I have designed my lumasuite case and I am interested in the following:\n\n" +
                    $"{basket}\n" +
                    $"Total without VAT: {collection.TotalWithoutVatText()}\n" +
                    $"VAT: {collection.VatText()}\n" +
                    $"Total: {collection.TotalText()}";
        }

        private string RenderBasketGroup(BasketGroupItem item)
        {
            string row = $"" +
                $"{item.Step.Name}\t\t" +
                $"{string.Join(", ", item.Items.Select(x => x.Name))}\t\t" +
                $"{item.Price:C}" +
                $"\n";
            return row;
        }
    }
}
