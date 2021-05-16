namespace ProductConfigurator.Core
{
    public static class CelloStepsFactory
    {
        public static Step Material => new Step(CelloSteps.Material, CelloSteps.Material.ToString());
        public static Step Color => new Step(CelloSteps.Color, CelloSteps.Color.ToString());
        public static Step Design => new Step(CelloSteps.Design, CelloSteps.Design.ToString());
        public static Step Accesories => new Step(CelloSteps.Accesories, CelloSteps.Accesories.ToString());
        public static Step End => new Step(CelloSteps.End, CelloSteps.End.ToString());
    }
}
