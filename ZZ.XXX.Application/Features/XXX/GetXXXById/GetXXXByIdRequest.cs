using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZ.XXX.Application.Features.XXX.GetXXXById
{
  public class GetXXXByIdRequest : IRequest<GetXXXByIdResponse>
  {
    public GetXXXByIdRequest(int id)
    {
      Id = id;
    }

    public int Id { get; }
  }
}
