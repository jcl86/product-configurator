using System;

namespace ProductConfigurator.Core;

public class NotFoundException<T> : NotFoundException
{
    public NotFoundException(string value, string fieldName = "id") : base($"{typeof(T).Name} with {fieldName} {value} was not found") { }
    public NotFoundException(int value, string fieldName = "id") : this(value.ToString(), fieldName) { }
    public NotFoundException(Guid value, string fieldName = "id") : this(value.ToString(), fieldName) { }
}

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}
