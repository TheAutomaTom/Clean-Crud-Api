using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.Responses;
using Mediator;

namespace CCA.Core.Application.Features.Cruds.ReadCrudById
{
  public class ReadCrudByIdRequest : IRequest<Result<Crud>>
  {
    public ReadCrudByIdRequest(int id)
    {
      Id = id;
    }

    public int Id { get; }

  }
}
