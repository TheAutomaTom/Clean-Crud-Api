using Mediator;
using ZZ.Core.Application.Features.XXX.GetXXXById;

namespace ZZ.Core.Application.Features.XXX.GetXXXById
{
  public class GetXXXByIdRequest : IRequest<GetXXXByIdResponse>
  {
    public GetXXXByIdRequest(int id)
    {
      Id = id;
    }

    public int Id { get; }
  }
}
