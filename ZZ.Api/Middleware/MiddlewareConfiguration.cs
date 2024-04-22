using ZZ.Api.Middleware;

namespace ZZ.Api.Middleware
{
  public static class MiddlewareConfiguration
  {
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<ExceptionHandler>();
    }
  }
}
