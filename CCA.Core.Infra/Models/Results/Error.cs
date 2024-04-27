using CCA.Core.Infra.Models.Responses;

namespace CCA.Core.Infra.Models.Results
{
  public record Error(string code, string? desc = null)
  {
    public static Error None = new Error(String.Empty);

    // This `implicit operator` will allows Error objects call the ctor of Result
    // so Error can be written and appear as a substituted return type for Result!
    public static implicit operator Result(Error error) => Result.Fail(error);
  }
}
