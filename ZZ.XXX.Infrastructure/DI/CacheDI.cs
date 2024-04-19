using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZZ.XXX.Application.Interfaces.Infrastructure;
using ZZ.XXX.Application.Models.Cache;
using ZZ.XXX.Infrastructure.Cache;

namespace ZZ.XXX.Infrastructure.DI
{
  public static class CacheDI 
  { 
    public static IServiceCollection AddCacheService(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection("Cache");
      services.Configure<CacheSettings>(settings);
      services.AddTransient<ICache, CacheService>();

      return services;
    }
  }
}



