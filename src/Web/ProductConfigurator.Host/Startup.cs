using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
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
            Api.Configuration
                .ConfigureServices(services, environment, configuration)
                .AddCustomAuthentication(configuration, environment);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product Configurator", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Configurator v1"));
            }

            var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<IEnumerable<string>>();
            Serilog.Log.Logger.Information("Origins: " + string.Join(", ", allowedOrigins));

            Api.Configuration.Configure(app, host =>
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
