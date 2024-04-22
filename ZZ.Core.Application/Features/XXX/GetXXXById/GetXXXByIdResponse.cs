using ZZ.Core.Domain._Deprecated;
using ZZ.Core.Domain.Common.Responses;

namespace ZZ.Core.Application.Features.XXX.GetXXXById
{
  public class GetXXXByIdResponse : BasicResponse
  {
    public GetXXXByIdResponse(XXXDto xxx = null)
    {
      XXX = xxx;
      IsOk = XXX != null;
    }

    public XXXDto? XXX { get; set; }

  }
}
