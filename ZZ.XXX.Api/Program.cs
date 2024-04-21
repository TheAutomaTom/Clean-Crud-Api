using Elk8.Lab.Api.DI;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Serilog;
using Serilog.Events;
using ZZ.XXX.Application.DI;
using ZZ.XXX.Config;
using ZZ.XXX.Config.Routing;
using ZZ.XXX.Config.Swagger;
using ZZ.XXX.Data.Config;
using ZZ.XXX.Infrastructure.DI;
using ZZ.XXX.Middleware;

namespace ZZ.XXX
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");      
      if(env == null)
      {
        throw new Exception("Environment not set");
      }
      
      var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env}.json", optional: true
        ).Build();

      builder.Services.ConfigureLogging(config, env);
      builder.Host.UseSerilog();

      Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();


      builder.Services.AddCorsPolicy(builder.Configuration);

      // Add services to the container.
      builder.Services.AddApplicationServices();
      builder.Services.AddInfrastructureServices(builder.Configuration);
      builder.Services.AddCacheService(builder.Configuration);
      
      builder.Services.AddElasticsearch(config);
      builder.Services.AddPersistenceServices(builder.Configuration);


      builder.Services.AddControllers();
      builder.Services.AddControllersWithViews(o =>
      {
        o.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
      });
      builder.Services.AddGraphQLConfig(builder.Configuration);

      builder.Services.AddEndpointsApiExplorer();

      builder.Services.AddSwagger();


      //******************************************************************************************//
      var app = builder.Build(); 
      //app.UseSerilogRequestLogging();
      

      app.UseCors(CorsConfig.Policy);

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

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
