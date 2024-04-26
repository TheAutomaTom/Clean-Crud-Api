using FluentValidation.Results;

namespace CCA.Core.Domain.Common.Responses
{
  public class BasicResponse
  {
    bool _isOk { get; set; } = true;
    public bool IsOk => ValidationErrors!.Count() == 0 && Exception == null;

    public IEnumerable<string>? Messages { get; set; }
    public IEnumerable<ValidationFailure>? ValidationErrors { get; set; } = new List<ValidationFailure>();
    public Exception? Exception { get; set; }

    public BasicResponse()
    {
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
