using Microsoft.Data.SqlClient;

namespace Onyx.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
