using FluentValidation.Results;
using ZZ.Core.Domain.Common.Responses;

namespace ZZ.Core.Domain.Common.Responses
{
  public class BasicResponse : IBasicResponse
  {
    public bool IsOk { get; set; }
    public IEnumerable<string>? Messages { get; set; }
    public IEnumerable<ValidationFailure>? ValidationErrors { get; set; }
    public Exception? Exception { get; set; }

    public BasicResponse() { }

    public BasicResponse(bool isOk, string message)
    {
      IsOk = isOk;
      Messages = new List<string>().Append(message);
    }

    public BasicResponse(Exception exception)
    {
      IsOk = false;
      Exception = exception;
    }

    public BasicResponse(IEnumerable<ValidationFailure> validationErrors)
    {
      IsOk = false;
      ValidationErrors = validationErrors;
    }



  }
}
