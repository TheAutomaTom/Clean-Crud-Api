using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CCA.Core.Application.Interfaces.Persistence;
using CCA.Data.Persistence.Repositories;
using CCA.Core.Application.Interfaces.Persistence.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Data.Persistence.Repositories.DbContexts;

namespace CCA.Data.Persistence.Config
{
  public static class DbContextConfigs
  {
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
      string connectionString;


      var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      if (env == "Test")
      {
        connectionString = Environment.GetEnvironmentVariable("GeneralDb-Testing");
      }
      else
      {
        connectionString = $"{configuration.GetConnectionString("GeneralDb")}Database=Cruds;";
      }

      services.AddDbContext<GeneralDbContext>(options => options.UseSqlServer(connectionString));
           
      services.AddScoped<ICrudEntitiesRepository, CrudEntitiesRepository>();

      return services;
    }
  }
}
