using Mediator;

namespace ZZ.XXX.Application.Features.XXX.GetXXXById
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
