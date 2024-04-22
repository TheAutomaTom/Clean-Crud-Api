namespace ZZ.Core.Domain.Common.Responses
{
  public interface IBasicResponse
  {
    public bool IsOk { get; set; }

    IEnumerable<string>? Messages { get; set; }

    Exception? Exception { get; set; }
  }
}
