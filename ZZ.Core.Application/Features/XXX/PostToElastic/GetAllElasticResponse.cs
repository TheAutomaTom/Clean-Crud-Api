using ZZ.Core.Domain.Common.Responses;
using ZZ.Core.Domain.Dtos.Elastic;

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
