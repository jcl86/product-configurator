using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using ProductConfigurator.Core.Database;
using ProductConfigurator.Core.Modules.Administration.Users;

namespace ProductConfigurator.Core;

public static class IdentityExtensions
{
    public static IServiceCollection AddCustomAspnetIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<UserSettings>(configuration.GetSection("UserSettings"));
        services.AddScoped(x => x.GetRequiredService<IOptionsSnapshot<UserSettings>>().Value);

        string? connectionString = configuration.GetConnectionString("SqLite");
        if (connectionString is null)
        {
            throw new InvalidOperationException("Connection string is not configured");
        }
        
        services.AddDbContext<ApplicationContext>(options =>
            //options.UseSqlServer(connectionString));
            options.UseSqlite(connectionString));

        services.AddIdentityCore<User>()
            //.AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>()
            .AddRoles<Role>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ApplicationContext>();

        services.AddDataProtection();

        //services.AddScoped<UserManager<User>>();

        services.Configure<IdentityOptions>(options =>
        {
            //options.ClaimsIdentity.UserIdClaimType = CustomClaims.UserId;
            //options.ClaimsIdentity.UserNameClaimType = CustomClaims.Name;
            //options.ClaimsIdentity.RoleClaimType = CustomClaims.Role;
            //options.ClaimsIdentity.EmailClaimType = CustomClaims.Email;

            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;

            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            //options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });
        return services;
    }
}
