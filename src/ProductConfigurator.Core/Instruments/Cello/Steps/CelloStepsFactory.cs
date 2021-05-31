using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class CelloStepsFactory
    {
        private static Product Product => ProductFactory.Cello;

        public static Step Material => new Step()
        {
            Id = 1,
            Name = Steps.Material,
            Product = Product
        };

        public static Step Design => new Step()
        {
            Id = 2,
            Name = Steps.Design,
            Product = Product
        };

        public static Step DesignColor => new Step()
        {
            Id = 3,
            Name = Steps.DesignColor,
            Product = Product
        };
      
        public static Step End => new Step()
        {
            Id = 4,
            Name = Steps.End,
            Product = Product
        };

        public static List<Step> StepList => new List<Step>()
        {
            Material,
            Design,
            DesignColor
        };
    }
}
