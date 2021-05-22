using System.Collections.Generic;

namespace ProductConfigurator.Core
{
    public static class CelloStepsFactory
    {
        public static Step Material => new Step(CelloSteps.Material, CelloSteps.Material.ToString());
        public static Step Design => new Step(CelloSteps.Design, CelloSteps.Design.ToString());
        public static Step DesignColor => new Step(CelloSteps.DesignColor, "Design color");
        public static Step End => new Step(CelloSteps.End, CelloSteps.End.ToString());

        public static List<Step> Steps => new List<Step>()
        {
            Material,
            Design,
            DesignColor
        };
    }
}
