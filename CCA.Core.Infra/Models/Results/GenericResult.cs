using CCA.Core.Infra.Models.Results;
using FluentValidation.Results;
using static HotChocolate.ErrorCodes;

namespace CCA.Core.Infra.Models.Responses
{
  public class Result<T> : Result
  {
    public T? Data { get; set; } = default(T);

    public string DataType { get; set; }

    public Result() { }

    public Result(T data)
    {
      Data = data;
      DataType = data.GetType().Name;
    }

    public Result(Exception ex) : base(ex)
    {
      Data = default(T);
    }

    public Result(IEnumerable<ValidationFailure> validationErrors) : base(validationErrors)
    {
      Data = default(T);
    }

    public Result(IEnumerable<Error> errors) : base(errors)
    {
      Data = default(T);
    }

    public Result(Error error) : base(error)
    {
      Data = default(T);
    }

    public static Result<T> Ok(T data) => new Result<T>(data);
    public static Result<T> Fail(IEnumerable<ValidationFailure> vfs) => new(vfs);
    public static Result<T> Fail(IEnumerable<Error> errors) => new(errors);
    public static Result<T> Fail(Error error) => new(error);
    public static Result<T> Fail(Exception ex) => new(ex);
    public static Result<T> Fail() => new(new Error(CommonError.Unknown.ToString()));


  }
}

