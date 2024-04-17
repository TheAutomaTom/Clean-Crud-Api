using Whether_Advisory.XXX.Domain.DTOs;

namespace Whether_Advisory.XXX.Application.Features.XXX.GetXXXs
{
  public class GetXXXsResponse
  {
    public GetXXXsResponse(IEnumerable<XXXDto> xxxs)
    {
      XXXs = xxxs;
    }

    public IEnumerable<XXXDto> XXXs { get; set; }
  }
}
