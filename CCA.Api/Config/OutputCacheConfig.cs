using CCA.Core.Infra.Models.Cache;

namespace CCA.Api.Config
{
  public static class OutputCacheConfig
  {
    public static IServiceCollection AddLocalOutputCache(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddOutputCache(o => {
        o.AddBasePolicy(x => x.Expire(TimeSpan.FromMinutes(
            Convert.ToInt32(configuration["Cache:MinutesToLive"])
          )));
        o.AddBasePolicy(builder => builder
          .With(c => c.HttpContext.Request.Path.StartsWithSegments("/read"))
          .Tag("Crud-Reader"));
      }
      );


      //var settings = configuration.GetSection("Cache");
      //var cacheSettings = settings.Get<CacheSettings>();

      //// Now you can access the properties of the CacheSettings object
      //var address = cacheSettings.Address;
      //var password = cacheSettings.Password;

      //services.AddStackExchangeRedisOutputCache(options =>
      //{
      //  options.InstanceName = "CrudCache";

      //  options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions() {
      //    EndPoints = { cacheSettings.Address },
      //    Password = cacheSettings.Password,
      //    ConnectTimeout = cacheSettings.MillisecondsToTimeout
      //  };
      //});

      //services.AddOutputCache(options =>
      //{
      //  options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromMinutes(cacheSettings.MinutesToLive)));
      //});

      return services;
    }
  }
}
