using CCA.Core.Infra.Models.Results;
using FluentValidation.Results;

namespace CCA.Core.Infra.Models.Responses
{
  public class Result<T> : Result
  {
    public T? Data { get; set; } = default(T);

    // TODO: Think about how a non-generic Result is missing a detail about
    //        how a call may have been successful but the request was invalid.
    //      It seems like every request is at least Result<bool>,
    //        but then the data delivered may be more complicated like GetCrusRequest, which has pagination info.

    public string DataType { get; set; }

    public Result() { }

    public Result(T data)
    {
      Data = data;

      DataType = data != null 
        ? data!.GetType().Name 
        : String.Empty;
    }

    public Result(Exception ex) : base(ex)
    {
      Data = default(T);
    }

    public Result(IEnumerable<ValidationFailure> validationErrors) : base(validationErrors)
    {
      Data = default(T);
    }

    public Result(IEnumerable<ExpectedError> errors) : base(errors)
    {
      Data = default(T);
    }

    public Result(ExpectedError error) : base(error)
    {
      Data = default(T);
    }

    public static Result<T> Ok(T data) => new Result<T>(data);
    public static Result<T> Fail(IEnumerable<ValidationFailure> vfs) => new(vfs);
    public static Result<T> Fail(IEnumerable<ExpectedError> errors) => new(errors);
    public static Result<T> Fail(ExpectedError error) => new(error);
    public static Result<T> Fail(Exception ex) => new(ex);
    public static Result<T> Fail() => new(new ExpectedError(CommonError.Unknown.ToString()));


  }
}
