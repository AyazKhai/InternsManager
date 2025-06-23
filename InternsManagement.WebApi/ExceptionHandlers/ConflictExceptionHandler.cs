using InternsManagement.Application.CustoomExceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InternsManagement.WebApi.ExceptionHandlers
{
    internal sealed class ConflictExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ConflictExceptionHandler> _logger;

        public ConflictExceptionHandler(ILogger<ConflictExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ConflictException conflictEx)
                return false;

            _logger.LogWarning(conflictEx, "ConflictException: {Message}", conflictEx.Message);

            var problem = new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Title = "Conflict",
                Detail = conflictEx.Message
            };

            httpContext.Response.StatusCode = problem.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);
            return true;
        }
    }


}
