using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace Microsoft.Extensions.DependencyInjection;

public static class ModelBindingErrorExtensions
{
    public static IServiceCollection CustomizeModelBindingErrorBehaviour(this IServiceCollection services)
    {
        return services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Type = $"https://httpstatuses.com/400",
                };

                var errorList = problemDetails.Errors.Select(x => $"{x.Key}: {$"[{string.Join(", ", x.Value)}]"}");
                problemDetails.Detail = string.Join(", ", errorList);

                problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

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

        //By Default, the api would do this:
        //{
        //    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
        //    "title": "One or more validation errors occurred.",
        //    "status": 400,
        //    "traceId": "00-72b710915d487064fabf5ec5e7bfb281-c4b4c9bc40b76d7f-00",
        //    "errors": {
        //          "Email": [
        //             "The Email field is not a valid e-mail address."
        //          ]
        //    }
        //}

        //With this configuration, we manage to output invalid model state in this way:
        //{
        //    "type": "https://httpstatuses.com/400",
        //    "title": "One or more validation errors occurred.",
        //    "status": 400,
        //    "detail": "Email: [The Email field is not a valid e-mail address.]",
        //    "instance": "/api/account/login",
        //    "traceId": "0HML3H56PEGFP:0000000D",
        //    "errors": {
        //            "Email": [
        //                "The Email field is not a valid e-mail address."
        //        ]
        //    }
        //}
    }
}
