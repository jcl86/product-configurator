using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProductConfigurator.Core.MultiTenancy;

namespace ProductConfigurator.Core.Modules.Administration.Users.Infrastructure;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

        builder.HasMany(e => e.UserRoles)
            .WithOne(x => x.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
    }
}