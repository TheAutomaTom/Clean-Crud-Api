using CCA.Core.Application.Features.Cruds.UpdateCrud;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Responses;
using CCA.Core.Infra.Models.Responses;
using Mediator;

namespace CCA.Core.Application.Features.Cruds.CreateCrud
{
  public class CreateCrudRequest : IRequest<Result<Crud>>
  {
    public CreateCrudRequest()
    {

    }

    public CreateCrudRequest(CrudUpdate crud)
    {
      Name = crud.Name;
      Department = crud.Department;
      Description = crud.Description;
      Tags = crud.Tags;
    }

    /// <summary> Called when an Update is discovered to be a Create because no matching Id exists. </summary>
    public CreateCrudRequest(UpdateCrudRequest toCreate)
    {
      Name = toCreate.Name;
      Department = toCreate.Department;
      Description = toCreate.Description;
      Tags = toCreate.Tags;

    }


    public string Name { get; set; }

    public string Department { get; set; }
    public string Description { get; set; }
    public IEnumerable<string> Tags { get; set; }
  }
}
