using ZZ.XXX.Domain.Common.Responses;
using ZZ.XXX.Domain.Dtos;

namespace ZZ.XXX.Application.Features.XXX.GetXXXs
{
  public class GetXXXsResponse : BasicResponse
  {
    public GetXXXsResponse(IEnumerable<XXXDto> xxxs = null)
    {
      XXXs = xxxs;
      IsOk = XXXs != null;
    }
    
    public IEnumerable<XXXDto>? XXXs { get; set; }

  }
}
