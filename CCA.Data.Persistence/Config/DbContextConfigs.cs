using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CCA.Core.Application.Interfaces.Persistence;
using CCA.Data.Persistence.Repositories;
using CCA.Data.Persistence.Repositories.Common;
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

      services.AddDbContext<CrudContext>(options => options.UseSqlServer(connectionString));
           
      services.AddScoped(typeof(IAsyncRepository<>), typeof(EFCoreRepository<>));

      services.AddScoped<ICrudRepository, CrudRepository>();
      services.AddScoped<ICrudDetailRepository, CrudDetailRepository>();

      return services;
    }
  }
}
