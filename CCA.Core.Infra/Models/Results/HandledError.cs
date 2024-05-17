using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace CCA.Core.Infra.Models.Results
{
	public class HandledError
	{
		public ErrorType Type { get; set; }
		public object Value { get; set; }

		public HandledError(Exception ex)
		{
			Type = ErrorType.Exception;
			Value = ex;
		}
		public HandledError(ValidationFailure vf)
		{
			Type = ErrorType.Validation;
			Value = vf;
		}
		public HandledError(ExpectedError ee)
		{
			Type = ErrorType.ExpectedError;
			Value = ee;
		}

	}
}
