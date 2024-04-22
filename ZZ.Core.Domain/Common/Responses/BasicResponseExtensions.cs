using FluentValidation.Results;
using ZZ.Core.Domain.Common.Responses;

public static class BasicResponseExtensions
{

  // Untyped Okes
  public static BasicResponse Ok(this BasicResponse response)
  {
    response.IsOk = true;
    return response;
  }

  // Generic Okes
  public static BasicResponse<T> Ok<T>(this BasicResponse<T> response)
  {
    return (BasicResponse<T>)Ok((BasicResponse)response);
  }

  public static BasicResponse<T> Ok<T>(this BasicResponse<T> response, T payload)
  {
    response = (BasicResponse<T>)Ok((BasicResponse)response);
    response.Data = payload;

    return response;
  }

  // Untyped Fails
  public static BasicResponse Fail(this BasicResponse response)
  {
    response.IsOk = false;
    return response;
  }

  public static BasicResponse Fail(this BasicResponse response, Exception ex)
  {
    response.IsOk = false;
    response.Exception = ex;
    return response;
  }

  public static BasicResponse Fail(this BasicResponse response, IEnumerable<ValidationFailure> validationErrors)
  {
    response.IsOk = false;
    response.ValidationErrors.Concat(validationErrors);
    return response;
  }

  public static BasicResponse Fail(this BasicResponse response, string message)
  {
    response.IsOk = false;
    response.Messages ??= new List<string>().Append(message);
    return response;
  }


  //Generic Fails
  public static BasicResponse<T> Fail<T>(this BasicResponse<T> response, Exception ex)
  {
    return (BasicResponse<T>)Fail((BasicResponse)response, ex);
  }

  public static BasicResponse<T> Fail<T>(this BasicResponse<T> response, string message)
  {
    return (BasicResponse<T>)Fail((BasicResponse)response, message);
  }

  public static BasicResponse<T> Fail<T>(this BasicResponse<T> response, IEnumerable<ValidationFailure> validationErrors)
  {
    return (BasicResponse<T>)Fail((BasicResponse)response, validationErrors);
  }




}