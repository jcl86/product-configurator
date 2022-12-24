using Hellang.Middleware.ProblemDetails;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProductConfigurator.Core;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ProblemDetailsExtensions
{
    public static IServiceCollection ConfigureProblemDetails(this IServiceCollection services)
    {
        return services.AddProblemDetails(configure =>
        {
            configure.Map<DomainException>((context, exception) => exception.ToProblemDetails(StatusCodes.Status400BadRequest, context));
            configure.Map<NotFoundException>((context, exception) => exception.ToProblemDetails(StatusCodes.Status404NotFound, context));
            configure.Map<ArgumentException>((context, exception) => exception.ToProblemDetails(StatusCodes.Status400BadRequest, context));
            configure.Map<UnauthorizedAccessException>((context, exception) => exception.ToProblemDetails(StatusCodes.Status401Unauthorized, context));
            configure.Map<Exception>((context, exception) => 
            {
                Serilog.Log.Logger.Error(exception.Message);
                return exception.ToProblemDetails(StatusCodes.Status500InternalServerError, context, logWarning: false);
            });
        });
    }

    private static ProblemDetails ToProblemDetails(this Exception exception, int statusCode, HttpContext context, bool logWarning = true)
    {
        if (logWarning)
        {
            Serilog.Log.Logger.Warning(exception.Message);
        }

        ProblemDetails problemDetails = new()
        {
            Type = $"https://httpstatuses.com/{statusCode}",
            Title = statusCode switch
            {
                500 => "Internal server error",
                400 => "Bad request",
                404 => "Not found",
                _ => ""
            },
            Status = statusCode,
            Detail = statusCode != 500 ? exception.Message : "",
            Instance = context.Request.Path
        };

        problemDetails.Extensions.Add("traceId", context.TraceIdentifier);
        return problemDetails;
    }
}

//400 example
//{
//    "type": "https://httpstatuses.com/400",
//    "title": "Bad request",
//    "status": 400,
//    "detail": "An error in domain ocurred",
//    "instance": "/api/account/error3",
//    "traceId": "0HML3H70UJF64:0000000B"
//}

//500 example
//{
//    "type": "https://httpstatuses.com/500",
//    "title": "Internal server error",
//    "status": 500,
//    "detail": "",
//    "instance": "/api/account/error1",
//    "traceId": "0HML3H70UJF64:00000003"
//}