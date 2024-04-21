using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZZ.XXX.Application.Interfaces.Persistence;
using ZZ.XXX.Data.Persistence;
using ZZ.XXX.Data.Persistence.Common;
using ZZ.XXX.Data.DbContexts;

namespace ZZ.XXX.Data.Config
{
  public static class DbContextConfigs
  {
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<XXXDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("XXXDb")));

      services.AddScoped(typeof(IAsyncRepository<>), typeof(BasicRepository<>));

      services.AddScoped<IXXXRepository, XXXRepository>();

      return services;
    }
  }
}
