using HotChocolate.Types;

namespace CCA.Core.Domain.Models.Common
{
  // This allows multiple types to be returned in query results as an object named "SearchResult"
  [UnionType("SearchResult")]
  public interface IGqlResultType
  {



  }
}
