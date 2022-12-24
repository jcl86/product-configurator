using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductConfigurator.Domain;
using System;

namespace ProductConfigurator.Api
{
    public static class ProblemDetailsExtensions
    {
        public static IServiceCollection AddProblemDetails(this IServiceCollection services, IWebHostEnvironment environment,
          IConfiguration configuration)
        {
            return services.AddProblemDetails(configure =>
            {
                configure.IncludeExceptionDetails = (context, exception) => true;  //environment.EnvironmentName == "Development";
                configure.Map<DomainException>(exception =>
                {
                    Serilog.Log.Logger.Warning(exception.Message);
                    return new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status400BadRequest,
                        Type = nameof(DomainException)
                    };
                });
                configure.Map<NotFoundException>(exception =>
                {
                    return new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status404NotFound,
                        Type = nameof(NotFoundException)
                    };
                });

                configure.Map<Exception>(exception =>
                {
                    return new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.StackTrace,
                        Status = StatusCodes.Status500InternalServerError,
                        Type = nameof(Exception)
                    };
                });
            });
        }
    }
}
