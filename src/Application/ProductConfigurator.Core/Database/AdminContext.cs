using Microsoft.EntityFrameworkCore;

using ProductConfigurator.Core.Modules.Administration.Tenants;

namespace ProductConfigurator.Core.Database;

public class AdminContext : DbContext
{
    public AdminContext(DbContextOptions<AdminContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Tenant>().ToTable("Tenants");
        builder.Entity<Tenant>().HasKey(x => x.Id);
        builder.Entity<Tenant>().Property(x => x.Id).ValueGeneratedNever();
        builder.Entity<Tenant>().Property(x => x.Code).HasMaxLength(100).IsRequired();
        builder.Entity<Tenant>().Property(x => x.Name).HasMaxLength(200).IsRequired();
    }
}