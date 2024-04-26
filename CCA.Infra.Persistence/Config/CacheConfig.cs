using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZZ.Core.Application.Interfaces.Infrastructure;
using ZZ.Core.Plumbing.Models.Cache;
using ZZ.Infra.Persistence.Cache;

namespace ZZ.Infra.Persistence.Config
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



