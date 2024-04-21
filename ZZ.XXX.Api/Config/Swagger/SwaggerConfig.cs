using Microsoft.OpenApi.Models;
using System.Reflection;
using ZZ.XXX.Config.Swagger;

namespace ZZ.XXX.Config.Swagger
{
  public static class SwaggerConfig
  {

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {

      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "The Automa-Tom's Clean Architecture Template",
          Description = "Helping you hurry onto Expectations.",
          Contact = new OpenApiContact
          {
            Name = "Thomas Grossi",
            Url = new Uri("https://SurrealityCheck.org"),
            Email = "TheAutomaTom@gmail.com"
          }
        });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

        options.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);
        options.SchemaFilter<EnumSchemaFilter>();


      });




      return services;
    }


  }
}
