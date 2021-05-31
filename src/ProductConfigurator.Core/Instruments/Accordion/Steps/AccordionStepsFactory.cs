using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class AccordionStepsFactory
    {
        private static Product Product => ProductFactory.Accordion;

        public static Step AccordionType => new Step()
        {
            Id = 1,
            Name = Steps.AccordionType,
            Product = Product
        };

        public static Step CaseType => new Step()
        {
            Id = 2,
            Name = Steps.CaseType,
            Product = Product
        };

        public static Step Material => new Step()
        {
            Id = 3,
            Name = Steps.Material,
            Product = Product
        };

        public static Step Finish => new Step()
        {
            Id = 4,
            Name = Steps.Finish,
            Product = Product
        };

        public static Step Color => new Step()
        {
            Id = 5,
            Name = Steps.Color,
            Product = Product
        };
        public static Step Design => new Step()
        {
            Id = 6,
            Name = Steps.Design,
            Product = Product
        };
        public static Step DesignColor => new Step()
        {
            Id = 7,
            Name = Steps.DesignColor,
            Product = Product
        };

        public static Step Caps => new Step()
        {
            Id = 8,
            Name = Steps.Caps,
            Product = Product
        };

        public static Step Accesories => new Step()
        {
            Id = 9,
            Name = Steps.Accesories,
            Product = Product
        };
        public static Step End => new Step()
        {
            Id = 10,
            Name = Steps.End,
            Product = Product
        };

        public static List<Step> StepList => new List<Step>()
        {
            AccordionType,
            CaseType,
            Material,
            Finish,
            Color,
            Design,
            DesignColor,
            Caps,
            Accesories
        };
    }
}
