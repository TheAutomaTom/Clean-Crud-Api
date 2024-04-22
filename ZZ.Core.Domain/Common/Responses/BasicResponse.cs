using FluentValidation.Results;
using ZZ.Core.Domain.Common.Responses;

namespace ZZ.Core.Domain.Common.Responses
{
  public class BasicResponse
  {    
    public bool IsOk => ValidationErrors!.Count() == 0 && Exception == null;

    public IEnumerable<string>? Messages { get; set; }
    public IEnumerable<ValidationFailure>? ValidationErrors { get; set; } = new List<ValidationFailure>();
    public Exception? Exception { get; set; }

    public BasicResponse(bool isOk) { }

    public BasicResponse(string message)
    {
      Messages = new List<string>().Append(message);
    }

    public BasicResponse(Exception exception)
    {
      Exception = exception;
    }

    public BasicResponse(IEnumerable<ValidationFailure> validationErrors)
    {
      ValidationErrors = validationErrors;
    }



  }
}
