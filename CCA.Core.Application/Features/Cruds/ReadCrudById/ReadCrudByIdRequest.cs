using CCA.Core.Application.Features.Cruds.ReadCruds;
using Mediator;

namespace CCA.Core.Application.Features.Cruds.ReadCrudById
{
  public class ReadCrudByIdRequest : IRequest<ReadCrudByIdResponse>
  {
    public ReadCrudByIdRequest(int id)
    {
      Id = id;
    }

    public int Id { get; }

  }
}
