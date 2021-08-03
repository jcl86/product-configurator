using System;

namespace ProductConfigurator.Shared
{

    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
