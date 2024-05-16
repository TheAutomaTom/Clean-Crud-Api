using System;using CCA.Core.Infra.Models.Results;using FluentValidation.Results;namespace CCA.Core.Infra.Models.Responses{  public class Result  {
    public bool IsOk => ErrorList != null && ErrorList.Count > 0;		public IDictionary<ErrorType, object> ErrorList { get; set; }    public Result()    {    }    public Result(Exception exception)    {
			ErrorList ??= new Dictionary<ErrorType, object>() { {ErrorType.Exception, exception } };    }    public Result(IEnumerable<ValidationFailure> validationErrors)
		{
			ErrorList ??= new Dictionary<ErrorType, object>();

			foreach(var e in validationErrors)
			{
				ErrorList.Add(ErrorType.Validation, e);
			}

		}    public Result(IEnumerable<ExpectedError> errors)
		{
			ErrorList ??= new Dictionary<ErrorType, object>();

			foreach (var e in errors)
			{
				ErrorList.Add(ErrorType.ExpectedError, e);
			}

		}

		public Result(ExpectedError error)    {
			ErrorList ??= new Dictionary<ErrorType, object>() { {ErrorType.ExpectedError, error } };    }    public static Result Ok() => new();    public static Result Fail(IEnumerable<ValidationFailure> vfs) => new(vfs);    public static Result Fail(IEnumerable<ExpectedError> errors) => new(errors);    public static Result Fail(ExpectedError error) => new(error);    public static Result Fail(Exception ex) => new(ex);  }}