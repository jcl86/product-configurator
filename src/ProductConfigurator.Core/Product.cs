namespace ProductConfigurator.Core
{
    public class Product
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Product))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (Product)obj;

            return item.Id == Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Product left, Product right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Product left, Product right) => !(left == right);
    }
}
