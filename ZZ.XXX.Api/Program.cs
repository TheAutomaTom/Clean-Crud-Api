using System.Reflection;
using Microsoft.OpenApi.Models;
using ZZ.XXX.Application.DI;

namespace ZZ.XTEMPLATEX
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddCoreApplicationServices();

      // Add services to the container.

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "Whether Advisory System",
          Description = "Helping you hurry onto Expectations.",
          Contact = new OpenApiContact
          {
            Name = "Thomas Grossi",
            Url = new Uri("https://SurrealityCheck.org"),
            Email = "TheAutomaTom@gmail.com"
          }
        });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);
        //options.SchemaFilter<EnumSchemaFilter>();


      });

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

      app.Run();
    }
  }
}
