namespace CCA.Api.Config
{
  public static class CacheConfig
  {

    public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration config)
    {



      return services;
    }


  }
}
