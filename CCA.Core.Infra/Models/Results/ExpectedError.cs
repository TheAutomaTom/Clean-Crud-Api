using System.ComponentModel;
using CCA.Core.Infra.Models.Responses;

namespace CCA.Core.Infra.Models.Results
{
	public record ExpectedError(ErrorCode code, string? desc = null)
	{
		// This `implicit operator` will allows Error objects call the ctor of Result
		// so Error can be written and appear as a substituted return type for Result!
		public static implicit operator Result(ExpectedError error) => Result.Fail(error);

		public override string ToString() => $"Error: {code.ToString()}, {desc}.  ";

	}




}