using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductConfigurator.Core.Modules.Administration.Users.Infrastructure;

public class RoleTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasMany(e => e.UserRoles)
                .WithOne(x => x.Role)
                .HasForeignKey(uc => uc.RoleId)
                .IsRequired();
    }
}
