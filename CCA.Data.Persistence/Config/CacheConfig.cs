using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Data.Persistence.Cache;
using CCA.Core.Infra.Models.Cache;

namespace CCA.Data.Persistence.Config
{
  public static class CacheConfig
  {
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection("Cache");
      services.Configure<CacheSettings>(settings);
      services.AddTransient<ICache, CacheService>();

      return services;
    }
  }
}



