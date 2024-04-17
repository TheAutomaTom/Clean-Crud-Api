namespace Whether_Advisory.XXX.Domain.Common.Responses
{
  public interface IBasicResponse
  {
    bool IsOk { get; set; }

    IEnumerable<string> Messages { get; set; }

    IEnumerable<Exception>? Exceptions { get; set; }
  }
}
