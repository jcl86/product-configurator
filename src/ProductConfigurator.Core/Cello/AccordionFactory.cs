using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class AccordionFactory
    {
        public static IEnumerable<Item> Accesories => new List<Item>() { ExtraAside, Cushionextra };
    }
}
