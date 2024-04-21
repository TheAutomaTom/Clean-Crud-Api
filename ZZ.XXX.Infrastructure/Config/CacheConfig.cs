using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZZ.XXX.Application.Interfaces.Infrastructure;
using ZZ.XXX.Infrastructure.Cache;
using ZZ.XXX.Domain.Models.Cache;

namespace ZZ.XXX.Infrastructure.Config
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



