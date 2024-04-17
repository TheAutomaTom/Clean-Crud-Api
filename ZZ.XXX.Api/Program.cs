using ZZ.XXX.Application.DI;
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

      // Add services to the container.
      builder.Services.AddApplicationServices();
      builder.Services.AddInfrastructureServices(builder.Configuration);
      builder.Services.AddPersistenceServices(builder.Configuration);

      builder.Services.AddControllers();

      builder.Services.AddEndpointsApiExplorer();

      builder.Services.AddSwagger();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();

      app.MapControllers();

      app.UseCustomExceptionHandler();

      app.Run();
    }
  }
}
