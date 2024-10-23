using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bibosio.Common.Exceptions
{
    public class AppValidationExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<AppValidationExceptionHandler> _logger;

        public AppValidationExceptionHandler(ILogger<AppValidationExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not AppValidationException appValidationException)
            {
                return false;
            }

            _logger.LogError(appValidationException, "Exception occurred: {Message} {@ValidationResult}", appValidationException.Message, appValidationException.ValidationResult);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation Error",
                Detail = appValidationException.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            //await httpContext.Response.WriteAsJsonAsync(validationException.ValidationResult, cancellationToken);
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
