using FluentValidation.Results;

namespace ZZ.XXX.Domain.Common.Responses
{
  public class BasicResponse : IBasicResponse
  {
    public bool IsOk { get; set; } = false;
    public IEnumerable<string>? Messages { get; set; }
    public IEnumerable<ValidationFailure>? ValidationErrors { get; set; }
    public IEnumerable<Exception>? Exceptions { get; set; }

    public BasicResponse() { }

    public BasicResponse(bool isOk, string message)
    {
      IsOk = isOk;
      Messages = new List<string>().Append(message);
    }

    public BasicResponse(Exception exception)
    {
      IsOk = false;
      Exceptions = new List<Exception>().Append(exception);
    }

    public BasicResponse(IEnumerable<ValidationFailure> validationErrors)
    {
      IsOk = false;
      ValidationErrors = validationErrors;
    }



  }
}
