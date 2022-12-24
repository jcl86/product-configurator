using System;

namespace ProductConfigurator.Domain;

public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }
}
