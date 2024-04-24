using Mediator;
using ZZ.Core.Application.Features.Cruds.CreateCrud;

namespace ZZ.Core.Application.Features.Cruds.CreateCrud
{
  public class CreateCrudRequest : IRequest<CreateCrudResponse>
  {
    public string Name { get; set; }

    public string Department { get; set; }
    public string Description { get; set; }
    public IEnumerable<string> Tags { get; set; }
  }
}
