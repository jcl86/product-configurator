using Microsoft.EntityFrameworkCore;

using ProductConfigurator.Core.Modules.Administration.Shops;

namespace ProductConfigurator.Core.Database;

public class AdminContext : DbContext
{
    public AdminContext(DbContextOptions<AdminContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Shop>().ToTable("Shops");
        builder.Entity<Shop>().HasKey(x => x.Id);
        builder.Entity<Shop>().Property(x => x.Id).ValueGeneratedNever();
        builder.Entity<Shop>().Property(x => x.Code).HasMaxLength(100).IsRequired();
        builder.Entity<Shop>().Property(x => x.Name).HasMaxLength(200).IsRequired();
    }
}