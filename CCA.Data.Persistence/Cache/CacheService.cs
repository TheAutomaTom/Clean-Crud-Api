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

      var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      string connectionString;
      if (env == "Test")
      {
        connectionString = Environment.GetEnvironmentVariable("RedisCache-Testing");
      }
      else
      {
        connectionString = _settings.Address;
      }

      var expiry = _settings.MinutesToLive > 0 ? _settings.MinutesToLive : 5;
      _defaultLifetime = new TimeSpan(0, expiry, 0);

      _config = new ConfigurationOptions()
      {
        AbortOnConnectFail = true,
        User = _settings.User,
        Password = _settings.Password,
        EndPoints = { connectionString },
        SyncTimeout = _settings.MillisecondsToTimeout,
        AsyncTimeout = _settings.MillisecondsToTimeout,
        ConnectTimeout = _settings.MillisecondsToTimeout
      };

    }

    public async Task<Result<bool>> Create(string key, string value, TimeSpan? lifetime = null)
    {
      var expiry = lifetime ?? _defaultLifetime;

      bool created;
      try
      {
        var db = tryGetDatabase();
        created = db.StringSet(new RedisKey(key), new RedisValue(value), expiry);
      }
      catch (Exception ex)
      {
        var error = HandleException(ex);
        return Result<bool>.Fail(error);
      }

      return Result<bool>.Ok(created);
    }

    public async Task<Result<bool>> Create<T>(string key, T value, TimeSpan? lifetime = null)
    {
      var expiry = lifetime ?? _defaultLifetime;

      bool created;
      try
      {
        var json = JsonSerializer.Serialize(value);

        var db = tryGetDatabase();
        created = db.StringSet(new RedisKey(key), new RedisValue(json), expiry);
      }
      catch (Exception ex)
      {
        var error = HandleException(ex);
        return Result<bool>.Fail(error);
      }

      return Result<bool>.Ok(created);
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
      return Result<bool>.Ok(exists);
    }

    public async Task<Result<string>> ReadString(string key)
    {
      try
      {
        var db = tryGetDatabase();
        var value = db.StringGet(new RedisKey(key));

        // Even if the value is null or empty, this was a successful call to the cache.
        return Result<string>.Ok(value);

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

        if(!value.IsNullOrEmpty)
        {
          var result = JsonSerializer.Deserialize<T>(value);
          // Even if the value is null or empty, this was a successful call to the cache.
          return Result<T>.Ok(result);
        }

        return Result<T>.Ok(default);


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
      return Result<bool>.Ok(deleted);
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

    protected static ExpectedError HandleException(Exception ex)
    {
      var title = "CommonError.DistributedCacheError";

      if (ex is RedisConnectionException)
      {
        return new ExpectedError(title, $"Distributed cache error (Connection): {ex.Message}");
      }

      if (ex is RedisCommandException)
      {
        return new ExpectedError(title, $"Distributed cache error (Invalid Command): {ex.Message}");
      }

      if (ex is RedisException)
      {
        if (ex is RedisServerException)
        {
          return new ExpectedError(title, $"Distributed cache error (Sever): {ex.Message}");
        }
        return new ExpectedError(title, $"Distributed cache error (General): {ex.Message}");
      }

      if (ex is RedisTimeoutException)
      {
        return new ExpectedError(title, $"Redis cache error (Timeout): {ex.Message}");
      }

      return new ExpectedError(title, $"Redis cache error (Unknown): {ex.Message}");
    }

  }
}
