using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Infra.Persistence.EfCore;
using ZZ.Infra.Persistence.EfCore.Common;
using ZZ.Infra.Persistence.EfCore.DbContexts;
using ZZ.Infra.Persistence.Repositories;

namespace ZZ.Infra.Persistence.Config
{
  public static class DbContextConfigs
  {
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<CrudContext>(options => options.UseSqlServer(configuration.GetConnectionString("CrudDb")));
           
      services.AddScoped(typeof(IAsyncRepository<>), typeof(EFCoreRepository<>));

      services.AddScoped<ICrudRepository, CrudRepository>();
      services.AddScoped<ICrudDetailRepository, CrudDetailRepository>();

      return services;
    }
  }
}
