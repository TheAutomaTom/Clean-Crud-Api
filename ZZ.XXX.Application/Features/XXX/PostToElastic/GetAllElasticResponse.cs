using ZZ.XXX.Domain.Common.Responses;
using ZZ.XXX.Domain.Dtos.Elastic;

namespace ZZ.XXX.Application.Features.XXX.PostToElastic
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