using System;using FluentValidation.Results;using CCA.Core.Infra.ResultTypes;
namespace CCA.Core.Infra.ResultTypes
{
	public class Result
	{
		//public bool IsOk => ErrorList != null && ErrorList?.Count() != 0;
		public bool IsOk 
		{
			get
			{
				if(ErrorList != null)
				{
					if(ErrorList.Count() > 0)
					{
						return false;
					}
				}
				return true;
			}
		}		public IEnumerable<HandledError>? ErrorList { get; set; }

		public Result(){ }

		public Result(Exception exception)
		{
			ErrorList ??= new List<HandledError>() { new HandledError(exception) };
		}

		public Result(ValidationFailure validationError)
		{
			ErrorList ??= new List<HandledError>() { new HandledError(validationError) };
		}

		public Result(ExpectedError error)
		{
			ErrorList ??= new List<HandledError>() { new HandledError(error) };
		}

		public Result(HandledError error)
		{
			ErrorList ??= new List<HandledError>() { error };
		}

		public Result(IEnumerable<ValidationFailure> validationErrors)
		{
			ErrorList ??= new List<HandledError>();
			foreach (var e in validationErrors)
			{
				ErrorList.Append(new HandledError(e));
			}

		}

		public Result(IEnumerable<ExpectedError> errors)
		{
			ErrorList ??= new List<HandledError>();
			foreach (var e in errors)
			{
				ErrorList.Append(new HandledError(e));
			}

		}

		public Result(IEnumerable<HandledError> errors)
		{
			ErrorList ??= new List<HandledError>();
			foreach (var e in errors)
			{
				ErrorList.Append(e);
			}

		}

		public static Result Ok() => new();
		public static Result Fail(IEnumerable<ValidationFailure> vfs) => new(vfs);
		public static Result Fail(IEnumerable<ExpectedError> errors) => new(errors);
		public static Result Fail(ExpectedError error) => new(error);
		public static Result Fail(Exception ex) => new(ex);


	}}
