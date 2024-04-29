using System.Text.Json;
using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Core.Infra.Models.Cache;
using CCA.Core.Infra.Models.Responses;
using CCA.Core.Infra.Models.Results;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace CCA.Data.Persistence.Cache
{
  public class CacheService : ICache
  {
    readonly ILogger<CacheService> _logger;
    readonly CacheSettings _settings;   // from AppSettings
    readonly TimeSpan _defaultLifetime; // from AppSettings
    readonly ConfigurationOptions _config; // Redis class to create connection
    ConnectionMultiplexer _connection;

    public CacheService(IOptions<CacheSettings> settings, ILogger<CacheService> logger)
    {
      _logger = logger;

      _settings = settings.Value;

      _config = new ConfigurationOptions()
      {
        AbortOnConnectFail = false,
        User = _settings.User,
        Password = _settings.Password,
        EndPoints = { _settings.Address },
        SyncTimeout = _settings.MillisecondsToTimeout,
        AsyncTimeout = _settings.MillisecondsToTimeout,
        ConnectTimeout = _settings.MillisecondsToTimeout
      };
      _defaultLifetime = new TimeSpan(0, _settings.MinutesToLive, 0);
    }

    public async Task<Result<bool>> Create(string key, string value, TimeSpan? lifetime = null)
    {
      bool created;
      try
      {
        var db = tryGetDatabase();
        created = db.StringSet(new RedisKey(key), new RedisValue(value), lifetime);
      }
      catch (Exception ex)
      {
        var error = HandleException(ex);
        return Result<bool>.Fail(error);
      }

      return new Result<bool>(created);
    }

    public async Task<Result<bool>> Create<T>(string key, T value, TimeSpan? lifetime = null)
    {
      bool created;
      try
      {
        var json = JsonSerializer.Serialize(value);

        var db = tryGetDatabase();
        created = db.StringSet(new RedisKey(key), new RedisValue(json), lifetime);
      }
      catch (Exception ex)
      {
        var error = HandleException(ex);
        return Result<bool>.Fail(error);
      }

      return new Result<bool>(created);
    }

    public async Task<Result<bool>> Exists(string key)
    {
      bool exists;
      try
      {
        var db = tryGetDatabase();
        exists = db.KeyExists(new RedisKey(key));
      }
      catch (Exception ex)
      {
        var error = HandleException(ex);
        return Result<bool>.Fail(error);
      }
      return new Result<bool>(exists);
    }

    public async Task<Result<string>> ReadString(string key)
    {
      try
      {
        var db = tryGetDatabase();
        var value = db.StringGet(new RedisKey(key));

        // Even if the value is null or empty, this was a successful call to the cache.
        return new Result<string>(value);

      }
      catch (Exception ex)
      {
        var error = HandleException(ex);
        return Result<string>.Fail(error);
      }
    }

    public async Task<Result<T>> Read<T>(string key)
    {
      try
      {
        var db = tryGetDatabase();
        var value = db.StringGet(new RedisKey(key));

        var result = JsonSerializer.Deserialize<T>(value);

        // Even if the value is null or empty, this was a successful call to the cache.
        return new Result<T>(result);

      }
      catch (Exception ex)
      {
        var error = HandleException(ex);
        return Result<T>.Fail(error);
      }
    }

    public async Task<Result<bool>> Delete(string key)
    {
      bool deleted;
      try
      {
        var db = tryGetDatabase();
        deleted = db.KeyDelete(new RedisKey(key));
      }
      catch (Exception ex)
      {
        var error = HandleException(ex);
        return Result<bool>.Fail(error);
      }
      return new Result<bool>(deleted);
    }


    public string GetStatus()
    {
      try
      {
        var db = tryGetDatabase();
        var status = _connection.GetStatus();

        _logger.LogInformation($"Distributed cache status: {status}");
        return status;
      }
      catch (Exception ex)
      {
        return HandleException(ex).ToString();
      }
    }



    ConnectionMultiplexer configureConnection() => _connection = ConnectionMultiplexer.Connect(_config);

    IDatabase tryGetDatabase()
    {
      _connection ??= _connection ?? configureConnection();

      if (_connection.GetDatabase() != null)
      {
        return _connection.GetDatabase();
      }
      else
      {
        throw new Exception("Distributed cache connection is null.");
      }
    }

    protected static Error HandleException(Exception ex)
    {
      var title = "CommonError.DistributedCacheError";

      if (ex is RedisConnectionException)
      {
        return new Error(title, $"Distributed cache error (Connection): {ex.Message}");
      }

      if (ex is RedisCommandException)
      {
        return new Error(title, $"Distributed cache error (Invalid Command): {ex.Message}");
      }

      if (ex is RedisException)
      {
        if (ex is RedisServerException)
        {
          return new Error(title, $"Distributed cache error (Sever): {ex.Message}");
        }
        return new Error(title, $"Distributed cache error (General): {ex.Message}");
      }

      if (ex is RedisTimeoutException)
      {
        return new Error(title, $"Redis cache error (Timeout): {ex.Message}");
      }

      return new Error(title, $"Redis cache error (Unknown): {ex.Message}");
    }

  }
}
