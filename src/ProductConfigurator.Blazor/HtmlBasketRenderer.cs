using ProductConfigurator.Core;
using System;
using System.Linq;

namespace ProductConfigurator.Blazor
{
    public class HtmlBasketRenderer
    {
        private readonly ItemCollection collection;

        public HtmlBasketRenderer(ItemCollection collection)
        {
            this.collection = collection;
        }

        public string Render()
        {
            var basket = string.Join("", collection.Basket.Select(x => RenderBasketGroup(x)));
            return $"<table>{basket}</table>";
        }

        private string RenderBasketGroup(BasketGroupItem item)
        {
            string row = $"<tr>" +
                $"<td>{item.Step.Name}<td>" +
                $"<td>{string.Join(", ", item.Items.Select(x => x.Name))}<td>" +
                $"<td>{item.Price:C}<td>" +
                $"</tr>";
            return row;
        }
    }
}
