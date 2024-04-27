using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CCA.Api.Middleware
{
  /// <summary> This is only for handling unknown/ unanticipated exceptions (actual processing errors) </summary>
  public class ExceptionHandlerConfig : IExceptionHandler
  {
    readonly ILogger<ExceptionHandlerConfig> _logger;
    readonly string _env;

    public ExceptionHandlerConfig(ILogger<ExceptionHandlerConfig> logger)
    {
      _logger = logger;
      _env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
      _logger.LogError(exception, $"Exception occurred: {exception.Message}");


      var details = new ProblemDetails
      {
        Status = StatusCodes.Status500InternalServerError,
        Title = "Error",
        Type = "https://httpstatuses.com/500",
        // Hide some exception details in prod in case of security issues.  Logger will still record full messages.
        Detail = (_env == "Development" || _env == "Test") ? exception.Message : "An unexpected error occurred. Please try again later."
      };

      httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

      await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);
      return true;

    }
  }
}
