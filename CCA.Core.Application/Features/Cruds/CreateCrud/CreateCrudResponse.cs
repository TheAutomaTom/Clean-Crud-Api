using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.Common;

namespace CCA.Core.Application.Features.Cruds.CreateCrud
{
  public class CreateCrudResponse : BasicResponse
  {
    public CreateCrudResponse(Crud? crud = null) : base()
    {
      Crud = crud;

    }

    public Crud? Crud { get; set; }
  }
}
