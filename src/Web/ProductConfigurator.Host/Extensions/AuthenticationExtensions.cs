using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProductConfigurator.Api;
using System.Text;

namespace ProductConfigurator.Host
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            string apiKeyValue = configuration.GetValue<string>(key: Api.TokenGenerator.ApiSecretConfigurationName);

            var key = Encoding.ASCII.GetBytes(apiKeyValue);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
                            var userId = context.Principal.Identity.Name;

                            var user = await userManager.FindByIdAsync(userId);
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
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        NameClaimType = JwtClaimTypes.Name,
                        RoleClaimType = JwtClaimTypes.Role
                    };
                });
            return services;
        }
    }
}
