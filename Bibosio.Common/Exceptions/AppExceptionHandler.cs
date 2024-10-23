using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Bibosio.Common.Exceptions
{
    public class AppExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            int status = StatusCodes.Status500InternalServerError;
            string title = "An error occurred";

            switch (exception)
            {
                case ArgumentException:
                    status = StatusCodes.Status400BadRequest;
                    title = "Bad Request";
                    break;
                case ValidationException:
                    status = StatusCodes.Status400BadRequest;
                    title = "Validation error";
                    break;
                case NotFoundException:
                    status = StatusCodes.Status404NotFound;
                    title = "Not Found";
                    break;

            }

            var problemDetails = new ProblemDetails
            {
                Status = status,
                Title = title,
                Type = exception.GetType().Name,
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            };

            Activity? activity = httpContext.Features.Get<IHttpActivityFeature>()?.Activity;
            problemDetails.Extensions.TryAdd("traceId", activity?.Id);
            problemDetails.Extensions.TryAdd("requestId", httpContext.TraceIdentifier);

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                Exception = exception,
                HttpContext = httpContext,
                ProblemDetails = problemDetails
            });

        }
    }
}
