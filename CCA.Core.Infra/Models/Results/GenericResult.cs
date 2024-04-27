using CCA.Core.Infra.Models.Results;
using FluentValidation.Results;

namespace CCA.Core.Infra.Models.Responses
{
  public class Result<T>
  {
    public T? Data { get; set; } = default(T);

    bool _isOk { get; set; } = true;
    public bool IsOk => ValidationErrors!.Count() == 0 && Exception == null;

    public IEnumerable<ValidationFailure>? ValidationErrors { get; set; } = new List<ValidationFailure>();
    public IEnumerable<Error> Errors { get; }
    public Exception? Exception { get; set; }

    public Result(T data)
    {
      Data = data;
    }

    public Result(Exception exception)
    {
      Data = default(T);
      Exception = exception;
    }

    public Result(IEnumerable<ValidationFailure> validationErrors)
    {
      Data = default(T);
      ValidationErrors = validationErrors;
    }

    public Result(IEnumerable<Error> errors)
    {
      Data = default(T);
      Errors = errors;
    }

    public Result(Error error)
    {
      Data = default(T);
      Errors ??= new List<Error>() { error };
    }

    public static Result<T> Ok(T data) => new Result<T>(data);
    public static Result<T> Fail(IEnumerable<ValidationFailure> vfs) => new(vfs);
    public static Result<T> Fail(IEnumerable<Error> errors) => new(errors);
    public static Result<T> Fail(Error error) => new(error);
    public static Result<T> Fail(Exception ex) => new(ex);


  }
}

