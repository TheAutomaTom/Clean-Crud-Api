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
        .Enrich.WithMachineName()
        .WriteTo.Debug()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(configureElasticSink(config, env))
        .Enrich.WithProperty("Environment", env)
        .ReadFrom.Configuration(config)
        .CreateLogger();
      
      Log.Logger.Information($"Logger configured.");

    }

    static ElasticsearchSinkOptions configureElasticSink(IConfiguration config, string env)
    {
      var url = config.GetValue<string>("Elastic:Url");
      return new ElasticsearchSinkOptions(new Uri(url))
      {
        ModifyConnectionSettings = x => x.BasicAuthentication(config["Elastic:Username"], config["Elastic:Password"]),
        AutoRegisterTemplate = true,
        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.Replace(".", "-")}-{env}-{DateTime.UtcNow:yyyy-MM}",

        // TODO: Move to Appsettings
        NumberOfReplicas = 1,
        NumberOfShards = 2
      };
    }


  }
}
