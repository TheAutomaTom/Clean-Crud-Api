using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.Responses;

namespace CCA.Core.Application.Features.Cruds.CreateCrud
{
  public class CreateCrudResponse : Result
  {
    public CreateCrudResponse(Crud? crud = null) : base()
    {
      Crud = crud;

    }

    public Crud? Crud { get; set; }
  }
}
