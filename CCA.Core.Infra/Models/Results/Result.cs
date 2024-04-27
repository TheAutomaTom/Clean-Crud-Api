using CCA.Core.Infra.Models.Results;
using FluentValidation.Results;

namespace CCA.Core.Infra.Models.Responses
{
  public class Result
  {
    bool _isOk { get; set; } = true;
    public bool IsOk => ValidationErrors!.Count() == 0 && Exception == null;

    public IEnumerable<ValidationFailure>? ValidationErrors { get; set; } = new List<ValidationFailure>();
    public IEnumerable<Error> Errors { get; }
    public Exception? Exception { get; set; }

    public Result()
    {
    }

    public Result(Exception exception)
    {
      Exception = exception;
    }

    public Result(IEnumerable<ValidationFailure> validationErrors)
    {
      ValidationErrors = validationErrors;
    }

    public Result(IEnumerable<Error> errors)
    {
      Errors = errors;
    }

    public Result(Error error)
    {
      Errors ??= new List<Error>() { error };
    }

    public static Result Ok() => new();
    public static Result Fail(IEnumerable<ValidationFailure> vfs) => new(vfs);
    public static Result Fail(IEnumerable<Error> errors) => new(errors);
    public static Result Fail(Error error) => new(error);
    public static Result Fail(Exception ex) => new(ex);


  }
}

