using CCA.Api.Config;
using CCA.Api.Config.Routing;
using CCA.Api.Config.Swagger;
using CCA.Api.Middleware;
using CCA.Core.Application.Config;
using CCA.Data.Infra.Config;
using CCA.Data.Persistence.Config;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Serilog;

namespace CCA.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //******************************************************************************************//
      var builder = WebApplication.CreateBuilder(args);
      //******************************************************************************************//

      var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      if (env == null)
      {
        // Set the default environment to Development
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        env ??= Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      }

      var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env}.json", optional: true
        ).Build();

      builder.Services.AddLogger(config, env);
      builder.Host.UseSerilog();

      builder.Services.AddCorsPolicy(builder.Configuration);

      // Internal services
      builder.Services
        .AddDbContexts(builder.Configuration)
        .AddMeditorSupport()
        .AddCache(builder.Configuration)
        .AddElasticsearch(config);

      builder.Services.AddEmailService(builder.Configuration);

      // Exposed features
      builder.Services.AddGraphQL(builder.Configuration);

      builder.Services.AddControllers();
      builder.Services.AddControllersWithViews(o =>
      {
        o.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
      });

      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwagger();


      builder.Services.AddDataProtection()
          .PersistKeysToFileSystem(new DirectoryInfo(@"..\Docker\keys"));


      //******************************************************************************************//
      var app = builder.Build();
      //******************************************************************************************//

      app.UseCors(CorsConfig.Policy);

      app.UseSwagger();
      app.UseSwaggerUI();

      app.UseHttpsRedirection();

      app.UseAuthorization();

      app.MapControllers();
      app.UseRouting();
      app.MapGraphQL();

      app.UseCustomExceptionHandler();

      app.Run();
    }
  }
}
