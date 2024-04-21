using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZ.XXX.Domain.Common.Responses;
using ZZ.XXX.Domain.Dtos;

namespace ZZ.XXX.Application.Features.XXX.PostToElastic
{
  public class PostToElasticResponse : BasicResponse
  {
    public PostToElasticResponse(string result)
    {
      Result = result;
      IsOk = Result == "Created";
    }

    public string Result { get; set; }
  }
}
