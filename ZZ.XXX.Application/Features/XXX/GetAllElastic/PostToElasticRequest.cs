using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediator;
using ZZ.XXX.Domain.Dtos;

namespace ZZ.XXX.Application.Features.XXX.PostToElastic
{
  public class PostToElasticRequest : IRequest<PostToElasticResponse>
  {
    public PostToElasticRequest(XXXDto xxx)
    {
      XXX = xxx;
    }

    public XXXDto XXX { get; }
  }
}
