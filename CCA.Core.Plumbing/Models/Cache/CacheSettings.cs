namespace CCA.Core.Infra.Models.Cache
{
  public class CacheSettings
  {
    public string Provider { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int MinutesToLive { get; set; } = 5;
    public int SecondToTimeout { get; set; } = 5;

  }
}
