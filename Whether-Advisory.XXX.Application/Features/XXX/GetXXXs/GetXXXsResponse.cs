using Whether_Advisory.XXX.Domain.Dtos;

namespace Whether_Advisory.XXX.Application.Features.XXX.GetXXXs
{
  public class GetXXXsResponse
  {
    public GetXXXsResponse(IEnumerable<XXXDto> xxxs)
    {
      XXXs = xxxs;
    }
    public GetXXXsResponse(IEnumerable<string> validationErrors)
    {
      ValidationErrors = validationErrors;
    }

    public IEnumerable<XXXDto> XXXs { get; set; }
    public IEnumerable<string> ValidationErrors{ get; set; }

  }
}
