using System.Reflection;
using Microsoft.OpenApi.Models;

namespace CCA.Api.Config.Swagger
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
          Title = "Clean Crud Architecture",
          Description = "A basic C.R.U.D. api.",
          Contact = new OpenApiContact
          {
            Name = "Thomas Grossi",
            Email = "TheAutomaTom@gmail.com"
          }
        });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

        options.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);
        options.SchemaFilter<EnumSchemaFilter>();


        // Add Auth token dialog
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          In = ParameterLocation.Header,
          Description = "Please enter a valid token",
          Name = "Authorization",
          Type = SecuritySchemeType.Http,
          BearerFormat = "JWT",
          Scheme = "Bearer"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
              new OpenApiSecurityScheme
              {
                Reference = new OpenApiReference
                {
                  Type=ReferenceType.SecurityScheme,
                  Id="Bearer"
                }
              },
              new string[]{}
            }
        });
      });




      return services;
    }


  }
}
