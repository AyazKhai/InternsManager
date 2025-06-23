using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InternsManagement.WebApi.ExceptionHandlers
{
    internal sealed class InvalidOperationExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<InvalidOperationExceptionHandler> _logger;

        public InvalidOperationExceptionHandler(ILogger<InvalidOperationExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not InvalidOperationException invalidOpEx)
                return false;

            _logger.LogWarning(invalidOpEx, "InvalidOperationException: {Message}", invalidOpEx.Message);

            var problem = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = invalidOpEx.Message
            };

            httpContext.Response.StatusCode = problem.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);
            return true;
        }
    }
}
