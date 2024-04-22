using ZZ.Core.Domain._Deprecated;
using ZZ.Core.Domain.Common.Responses;

namespace ZZ.Core.Application.Features.XXX.GetXXXs
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
