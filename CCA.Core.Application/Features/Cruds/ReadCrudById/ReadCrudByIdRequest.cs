using CCA.Core.Domain.Models.Cruds;
using Mediator;
using CCA.Core.Infra.ResultTypes;

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
