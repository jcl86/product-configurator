namespace ProductConfigurator.Core
{
    public class Step
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public Product Product { get; init; }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Step))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (Step)obj;

            return item.Id == Id && item.Product == Product;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Step left, Step right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Step left, Step right) => !(left == right);


        public bool WasCompleted(Step step) => step.Id < Id;

        public bool IsDesign() => Name.ToLower().Equals("design");
        public bool IsColor() => Name.ToLower().Contains("color");
        public bool IsEnd() => Name.Equals(Steps.End);
    }
}
