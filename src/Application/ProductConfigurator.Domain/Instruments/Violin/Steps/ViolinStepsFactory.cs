using System.Collections.Generic;

namespace ProductConfigurator.Domain
{
    public static class ViolinStepsFactory
    {
        private static Product Product => ProductFactory.Violin;

        public static Step Material => new Step()
        {
            Id = 1,
            Name = Steps.Material,
            Product = Product
        };

        public static Step Finish => new Step()
        {
            Id = 2,
            Name = Steps.Finish,
            Product = Product
        };

        public static Step Color => new Step()
        {
            Id = 3,
            Name = Steps.Color,
            Product = Product
        };
        public static Step Design => new Step()
        {
            Id = 4,
            Name = Steps.Design,
            Product = Product
        };
        public static Step DesignColor => new Step()
        {
            Id = 5,
            Name = Steps.DesignColor,
            Product = Product
        };

        public static Step End => new Step()
        {
            Id = 6,
            Name = Steps.End,
            Product = Product
        };

        public static List<Step> StepList => new List<Step>()
        {
            Material,
            Finish,
            Color,
            Design,
            DesignColor
        };
    }
}
