using ProductConfigurator.Core.MultiTenancy;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Core.Modules.Products.Products;
public class Product : Entity<int>, IHasTenant
{
    public string Name { get; private set; }
    public int? TenantId { get; set; }

    public Product(int id, string name) : base(id)
    {
        Name = name;
    }
}
