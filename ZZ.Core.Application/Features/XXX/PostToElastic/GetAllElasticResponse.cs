using ZZ.Core.Domain._Deprecated.Elastic;
using ZZ.Core.Domain.Common.Responses;

namespace ZZ.Core.Application.Features.XXX.PostToElastic
{
  public class GetAllElasticResponse : BasicResponse
  {
    public GetAllElasticResponse(IEnumerable<XXXEls> results)
    {
      Results = results;
      IsOk = results != null;
    }

    public IEnumerable<XXXEls> Results { get; set; }
  }

}
