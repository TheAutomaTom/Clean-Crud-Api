using Microsoft.Extensions.Options;
using StackExchange.Redis;
using ZZ.XXX.Application.Interfaces.Infrastructure;
using ZZ.XXX.Application.Models.Cache;

namespace ZZ.XXX.Infrastructure.Cache
{
  public class CacheService : ICache
  {
    readonly CacheSettings _settings; // from AppSettings
    readonly TimeSpan _defaultLifetime; // from AppSettings
    readonly ConfigurationOptions _config; // Redis class to create connection
    ConnectionMultiplexer _connection;


    public CacheService(IOptions<CacheSettings> settings)
    {
      _settings = settings.Value;

      _config = new ConfigurationOptions()
      {
        AbortOnConnectFail = false,
        User = _settings.User,
        Password = _settings.Password,
        EndPoints = { _settings.Address },
        SyncTimeout = _settings.SecondToTimeout * 1000, 
        AsyncTimeout = _settings.SecondToTimeout * 1000, 
        ConnectTimeout = _settings.SecondToTimeout * 1000
      };
      _defaultLifetime = new TimeSpan(0, _settings.MinutesToLive, 0);
    }

    public Task<bool> Create(string key, string value, TimeSpan? lifetime = null)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Exists(string key)
    {
      throw new NotImplementedException();
    }

    public Task<string> Read(string key)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Delete(string key)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Delete(IEnumerable<string> keys)
    {
      throw new NotImplementedException();
    }

    void configureConnection() => _connection = ConnectionMultiplexer.Connect(_config);

    IDatabase tryGetDatabase()
    {
      try
      {
        if (_connection == null)
        {
          configureConnection();
        }
        if (_connection.GetDatabase() != null)
        {
          return _connection.GetDatabase();
        }
        else
        {
          throw new Exception("Unable to connect to Redis cache.");
        }
      }
      catch
      {
        throw new Exception("Unable to connect to Redis cache.");
      }
    }
  }
}
