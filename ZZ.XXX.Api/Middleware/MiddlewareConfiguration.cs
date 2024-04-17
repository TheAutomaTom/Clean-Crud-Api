using ZZ.XXX.Middleware;

namespace ZZ.XXX.Middleware
{
    public static class MiddlewareConfiguration
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandler>();
        }
    }
}
