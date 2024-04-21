using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace ZZ.XXX.Application.DI
{
  public static class LoggerConfig
  {
    public static void ConfigureLogging(this IServiceCollection services, IConfiguration config, string env)
    {
      // Setup Logger
      Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails()
        .WriteTo.Debug()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(
          new ElasticsearchSinkOptions(new Uri(config["Elastic:Url"]))
          {
            ModifyConnectionSettings = x => x.BasicAuthentication(config["Elastic:Username"], config["Elastic:Password"]),
            AutoRegisterTemplate = true,

            // TODO: Move to Appsettings
            IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.Replace(".", "-")}-{env}-{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}",
            NumberOfReplicas = 2,
            NumberOfShards = 1
          }
        )
        .Enrich.WithProperty("Environment", env)
        .ReadFrom.Configuration(config)
        .CreateLogger();

    }



  }
}
