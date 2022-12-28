namespace ProductConfigurator.Core;
public class Entity<T> where T : IEquatable<T>
{
    public T Id { get; private set; }
    
    public Entity(T id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        return ((Entity<T>)obj).Id.Equals(Id);
    }
    public override int GetHashCode() => Id.GetHashCode();
}
