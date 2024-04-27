using Mediator;
using CCA.Core.Infra.Models.Common;

namespace CCA.Core.Application.Features.Cruds.DeleteCrudById
{
  public class DeleteCrudByIdRequest : IRequest<BasicResponse>
  {
    public DeleteCrudByIdRequest(int id)
    {
      Id = id;
    }

    public int Id { get; }
  }
}
