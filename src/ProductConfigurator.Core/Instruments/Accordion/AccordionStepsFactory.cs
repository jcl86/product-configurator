namespace ProductConfigurator.Core
{
    public static class AccordionStepsFactory
    {
        public static Step AccordionType => new Step(AccordionSteps.AccordionType, "Accordion type");
        public static Step CaseType => new Step(AccordionSteps.CaseType, "Case type");
        public static Step Material => new Step(AccordionSteps.Material, AccordionSteps.Material.ToString());
        public static Step Finish => new Step(AccordionSteps.Finish, AccordionSteps.Finish.ToString());
        public static Step Caps => new Step(AccordionSteps.Caps, AccordionSteps.Caps.ToString());
        public static Step Color => new Step(AccordionSteps.Color, AccordionSteps.Color.ToString());
        public static Step Design => new Step(AccordionSteps.Design, AccordionSteps.Design.ToString());
        public static Step Accesories => new Step(AccordionSteps.Accesories, AccordionSteps.Accesories.ToString());
        public static Step End => new Step(AccordionSteps.End, AccordionSteps.End.ToString());
    }
}
