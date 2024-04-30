using CCA.Core.Infra.Models.Responses;

namespace CCA.Core.Application.Interfaces.Infrastructure
{
  public interface ICache
  {
    Task<Result<bool>> Create(string key, string value, TimeSpan? lifetime = null);
    Task<Result<bool>> Create<T>(string key, T value, TimeSpan? lifetime = null);
    Task<Result<bool>> Exists(string key);
    Task<Result<string>> ReadString(string key);
    Task<Result<T>> Read<T>(string key);
    Task<Result<bool>> Delete(string key);
    string GetStatus();

  }
}
