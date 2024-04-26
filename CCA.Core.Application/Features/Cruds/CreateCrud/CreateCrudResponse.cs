using CCA.Core.Domain.Common.Responses;
using CCA.Core.Domain.Models.Cruds;

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
