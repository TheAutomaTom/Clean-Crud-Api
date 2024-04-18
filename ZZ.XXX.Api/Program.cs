using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using ZZ.XXX.Application.DI;
using ZZ.XXX.Config;
using ZZ.XXX.Config.Routing;
using ZZ.XXX.Config.Swagger;
using ZZ.XXX.Data.Config;
using ZZ.XXX.GraphQL.Queries;
using ZZ.XXX.DI;
using ZZ.XXX.Infrastructure.DI;
using ZZ.XXX.Middleware;

namespace ZZ.XXX
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddCorsPolicy(builder.Configuration);

      // Add services to the container.
      builder.Services.AddApplicationServices();
      builder.Services.AddInfrastructureServices(builder.Configuration);
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
      app.UseEndpoints(e =>
      {
        e.MapGraphQL();
      });

      app.UseCustomExceptionHandler();

      app.Run();
    }
  }
}
