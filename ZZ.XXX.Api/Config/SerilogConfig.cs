using Serilog.Sinks.Elasticsearch;
using Serilog;
using System.Reflection;
using Serilog.Exceptions;

namespace ZZ.XXX.Config
{
  public static class SerilogConfig
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
