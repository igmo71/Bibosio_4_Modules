using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibosio.Common.Exceptions
{
    public class AppExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails
            {
                //Status = exception switch
                //{
                //    ArgumentException => StatusCodes.Status400BadRequest,
                //    AppNotFoundException => StatusCodes.Status404NotFound,
                //    _ => StatusCodes.Status500InternalServerError
                //},
                Title = "An error occurred",
                Type = exception.GetType().Name,
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            };

            //Activity? activity = httpContext.Features.Get<IHttpActivityFeature>()?.Activity;
            //problemDetails.Extensions.TryAdd("traceId", activity?.Id);
            //problemDetails.Extensions.TryAdd("requestId", httpContext.TraceIdentifier);

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                Exception = exception,
                HttpContext = httpContext,
                ProblemDetails = problemDetails
            });

        }
    }
}
