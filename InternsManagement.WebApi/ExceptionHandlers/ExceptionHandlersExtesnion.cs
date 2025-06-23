using InternsManagement.Application.ServiceInterfaces;
using InternsManagement.Application.Services;

namespace InternsManagement.WebApi.ExceptionHandlers
{
    public static class ExceptionHandlersExtesnion
    {
        public static void AddCustomExceptionsHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<NotFoundExceptionHandler>();
            services.AddExceptionHandler<ConflictExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddExceptionHandler<InvalidOperationExceptionHandler>();
            services.AddProblemDetails();


        }
    }
}
