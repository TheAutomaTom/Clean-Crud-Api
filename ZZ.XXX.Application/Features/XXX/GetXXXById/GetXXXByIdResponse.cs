using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZ.XXX.Domain.Common.Responses;
using ZZ.XXX.Domain.Dtos;

namespace ZZ.XXX.Application.Features.XXX.GetXXXById
{
  public class GetXXXByIdResponse : BasicResponse
  {
    public GetXXXByIdResponse(XXXDto xxx = null)
    {
      XXX = xxx;
      IsOk = XXX != null;
    }

    public XXXDto? XXX { get; set; }

  }
}
