namespace ProductConfigurator.Core
{
    public class Step
    {
        private readonly int id;
        private readonly string name;

        public InstrumentType InstrumentType { get; }

        public Step(AccordionSteps step, string name)
        {
            id = (int)step;
            this.name = name;
            InstrumentType = InstrumentType.Accordion;
        }

        public Step(ViolinSteps step, string name)
        {
            id = (int)step;
            this.name = name;
            InstrumentType = InstrumentType.Violin;
        }

        public Step(CelloSteps step, string name)
        {
            id = (int)step;
            this.name = name;
            InstrumentType = InstrumentType.Cello;
        }

        public override string ToString() => name;

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Step))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (Step)obj;

            return item.id == id && item.InstrumentType == InstrumentType;
        }

        public override int GetHashCode() => id.GetHashCode();

        public static bool operator ==(Step left, Step right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Step left, Step right) => !(left == right);
    }
}
