using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Serilog;
using ZZ.Infra.Persistence.Config;
using ZZ.Api.Config;
using ZZ.Api.Config.Routing;
using ZZ.Api.Config.Swagger;
using ZZ.Api.Middleware;
using ZZ.Core.Application.Config;
using ZZ.Infra.Services.Config;

namespace ZZ.Api
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
        throw new Exception("Environment not set");
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
