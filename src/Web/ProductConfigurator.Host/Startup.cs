using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

using ProductConfigurator.Core;
using ProductConfigurator.Core.Database;

using System.Collections.Generic;
using System.Linq;

namespace ProductConfigurator.Host
{
    public class Startup
    {
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ApiConfiguration
                .ConfigureServices(services, configuration)
                .AddCustomAuthentication(configuration, environment);

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product Configurator", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context, ApplicationInitializer initializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Configurator v1"));
            }

            context.Database.Migrate();
            initializer.SeedUsers().Wait();
            
            IEnumerable<string>? allowedOrigins = configuration.GetSection("AllowedOrigins").Get<IEnumerable<string>>();

            if (allowedOrigins is null || !allowedOrigins.Any())
            {
                throw new Exception("Allowed origins are not configured in appsettings.json");
            }
            
            Serilog.Log.Logger.Information("Origins: " + string.Join(", ", allowedOrigins));
            
            ApiConfiguration.Configure(app, host =>
            {
                return host
                    .UseCors(policy =>
                         policy.WithOrigins(allowedOrigins.ToArray())
                         .AllowAnyMethod()
                         .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
                         .AllowCredentials())
                    .UseHttpsRedirection()
                    .UseDefaultFiles()
                    .UseStaticFiles();
            });
        }
    }
}
