namespace ProductConfigurator.Core
{
    public static class ViolinStepsFactory
    {
        public static Step Material => new Step(ViolinSteps.Material, ViolinSteps.Material.ToString());
        public static Step Finish => new Step(ViolinSteps.Finish, ViolinSteps.Finish.ToString());
        public static Step Color => new Step(ViolinSteps.Color, ViolinSteps.Color.ToString());
        public static Step Design => new Step(ViolinSteps.Design, ViolinSteps.Design.ToString());
        public static Step Accesories => new Step(ViolinSteps.Accesories, ViolinSteps.Accesories.ToString());
        public static Step End => new Step(ViolinSteps.End, ViolinSteps.End.ToString());
    }
}
