using IdentityModel;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;

using ProductConfigurator.Core.Modules.Administration.Users;
using ProductConfigurator.Core.MultiTenancy;

using System.Linq.Expressions;
using System.Reflection;

namespace ProductConfigurator.Core.Database;
public class ApplicationContext : IdentityDbContext<User, Role,
    string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    private readonly int? tenantId;
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options, ITenantProvider tenantProvider) : base(options) 
    {
        tenantId = tenantProvider.CurrentTenantId;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<IdentityUserClaim<string>>(b => b.ToTable("UserClaims"));
        builder.Entity<UserRole>(b => b.ToTable("UserRoles"));
        builder.Entity<IdentityRoleClaim<string>>(b => b.ToTable("RoleClaims"));
        builder.Entity<IdentityUserLogin<string>>(b => b.ToTable("UserLogins"));
        builder.Entity<IdentityUserToken<string>>(b => b.ToTable("UserTokens"));

        if (tenantId.HasValue)
        {
            ApplyTenantFilter(builder, tenantId.Value);
        }
    }

    public static void ApplyTenantFilter(ModelBuilder modelBuilder, int tenantId)
    {
        //entity.Property<string>(nameof(IHasTenant.TenantCode)).HasMaxLength(100); //.IsRequired();
        //entity.HasQueryFilter(e => EF.Property<string>(e, nameof(IHasTenant.TenantCode)) == tenantCode);

        Expression<Func<IHasTenant, bool>> filterExpr = entity => entity.TenantId == tenantId;
        foreach (IMutableEntityType mutableEntityType in modelBuilder.Model.GetEntityTypes())
        {
            // check if current entity type is child of BaseModel
            if (mutableEntityType.ClrType.IsAssignableTo(typeof(IHasTenant)))
            {
                // modify expression to handle correct child type
                ParameterExpression parameter = Expression.Parameter(mutableEntityType.ClrType);
                Expression body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                LambdaExpression lambdaExpression = Expression.Lambda(body, parameter);

                // set filter
                mutableEntityType.SetQueryFilter(lambdaExpression);
            }
        }
    }
}