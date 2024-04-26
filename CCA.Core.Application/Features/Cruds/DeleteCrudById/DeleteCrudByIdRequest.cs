using CCA.Core.Domain.Common.Responses;
using Mediator;

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
