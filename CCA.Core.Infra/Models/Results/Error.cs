using System.ComponentModel;
using CCA.Core.Infra.Models.Responses;

namespace CCA.Core.Infra.Models.Results
{
  public record Error(string code, string? desc = null)
  {
    // This `implicit operator` will allows Error objects call the ctor of Result
    // so Error can be written and appear as a substituted return type for Result!
    public static implicit operator Result(Error error) => Result.Fail(error);

    public override string ToString() => $"Error: {code} - {desc}";

  }

  public enum CommonError
  {
    [Description("Unknown error.")] Unknown,
    [Description("Does not exist.")] DoesNotExist,
    [Description("Distributed Cache Error.")] DistributedCacheError
  }




}