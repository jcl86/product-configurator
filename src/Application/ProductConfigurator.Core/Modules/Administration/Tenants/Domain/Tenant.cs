using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Core.Modules.Administration.Tenants;
public class Tenant : Entity<int>
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public DateTime CreationDate { get; set; }

    public Tenant(int id, DateTime creationDate) : base(id)
    {
        CreationDate = creationDate;
    }
}
