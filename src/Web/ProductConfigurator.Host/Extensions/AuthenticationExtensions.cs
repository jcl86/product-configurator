using IdentityModel;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

using ProductConfigurator.Core.Modules.Administration.Account.Infrastructure;
using ProductConfigurator.Core.Modules.Administration.Users;

using System.Text;

namespace ProductConfigurator.Host;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        string? apiKeyValue = configuration.GetValue<string>(key: TokenGenerator.ApiSecretConfigurationName);

        if (apiKeyValue is null)
        {
            throw new Exception("Api secret is not configured in appsettings.json");
        }

        byte[] encodedKey = Encoding.ASCII.GetBytes(apiKeyValue);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        string? userId = context.Principal?.Identity?.Name;
                        if (userId is null)
                        {
                            throw new Exception("User id was not found in token");
                        }
                        
                        UserManager<User> userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
                        User? user = await userManager.FindByIdAsync(userId);
                        if (user is null)
                        {
                            context.Fail("Unauthorized");
                        }
                    }
                };
                options.RequireHttpsMetadata = environment.EnvironmentName == "Development";
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(encodedKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role
                };
            });
        return services;
    }
}
