using HotChocolate.Types;

namespace ZZ.Core.Domain.Dtos.GQL
{
  // This allows multiple types to be returned in query results as an object named "SearchResult"
  [UnionType("SearchResult")]
  public interface IGqlResultType
  {



  }
}
