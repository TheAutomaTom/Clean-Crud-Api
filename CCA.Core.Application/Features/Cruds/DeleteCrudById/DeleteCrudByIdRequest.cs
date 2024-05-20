using Mediator;
using CCA.Core.Infra.ResultTypes;

namespace CCA.Core.Application.Features.Cruds.DeleteCrudById
{
	public class DeleteCrudByIdRequest : IRequest<Result>
  {
    public DeleteCrudByIdRequest(int id)
    {
      Id = id;
    }

    public int Id { get; }
  }
}
