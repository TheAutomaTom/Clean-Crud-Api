using Mediator;
using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Core.Domain.Models.Cruds;

namespace CCA.Core.Application.Features.Cruds.CreateCrud
{
  public class CreateCrudRequest : IRequest<CreateCrudResponse>
  {
    public CreateCrudRequest()
    {

    }

    public CreateCrudRequest(Crud crud)
    {
      Name = crud.Name;
      Department = crud.Department;
      Description = crud.Detail.Description;
      Tags = crud.Detail.Tags;
    }


    public string Name { get; set; }

    public string Department { get; set; }
    public string Description { get; set; }
    public IEnumerable<string> Tags { get; set; }
  }
}
