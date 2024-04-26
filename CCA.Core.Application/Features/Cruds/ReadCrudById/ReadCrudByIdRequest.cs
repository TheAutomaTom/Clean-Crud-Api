using CCA.Core.Application.Features.Cruds.ReadCruds;
using CCA.Core.Domain.Common.Responses;
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
