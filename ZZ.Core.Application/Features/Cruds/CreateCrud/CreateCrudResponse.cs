using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZ.Core.Domain.Common.Responses;
using ZZ.Core.Domain.Models.Cruds;

namespace ZZ.Core.Application.Features.Cruds.CreateCrud
{
  public class CreateCrudResponse : BasicResponse
  {
    public CreateCrudResponse(Crud? crud = null) : base(crud != null)
    {
      Crud = crud;

    }

    public Crud? Crud { get; set; }
  }
}
