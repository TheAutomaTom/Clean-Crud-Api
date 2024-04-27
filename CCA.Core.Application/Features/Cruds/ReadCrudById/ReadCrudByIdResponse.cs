using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.Responses;

namespace CCA.Core.Application.Features.Cruds.ReadCrudById
{
  public class ReadCrudByIdResponse : Result
  {
    public ReadCrudByIdResponse()
    {
      
    }

    public ReadCrudByIdResponse(Crud crud)
    {
      Crud = crud;
    }

    public Crud Crud { get; }
  }
}
