using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ProductConfigurator.Api
{
    public static class CustomApiBehaviourExtensions
    {
        public static IServiceCollection AddCustomApiBehaviour(this IServiceCollection services)
        {
            return services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = false;
                options.SuppressInferBindingSourcesForParameters = false;

                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Type = $"https://httpstatuses.com/400"
                    };
                    problemDetails.Detail = string.Join(", ", problemDetails.Errors.Select(x =>
                        $"{x.Key}: {$"[{string.Join(", ", x.Value)}]"}"));
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes =
                         {
                            "application/problem+json",
                            "application/problem+xml"
                         }
                    };
                };
            });
        }
    }
}
