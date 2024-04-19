namespace ZZ.XXX.Application.Interfaces.Infrastructure
{
  public interface ICache
  {
    Task<bool> Create(string key, string value, TimeSpan? lifetime = null);
    Task<bool> Exists(string key);
    Task<string> Read(string key);
    Task<bool> Delete(string key);
    Task<bool> Delete(IEnumerable<string> keys);

  }
}
