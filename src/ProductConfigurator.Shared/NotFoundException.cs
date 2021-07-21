using System;

namespace ProductConfigurator.Shared
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string objectName, string id) : base($"No se encontró el objeto {objectName ?? ""} con id {id ?? ""}") { }

        public NotFoundException(string objectName, int id) : this(objectName, id.ToString()) { }
        public NotFoundException(string objectName, long id) : this(objectName, id.ToString()) { }
    }
}
