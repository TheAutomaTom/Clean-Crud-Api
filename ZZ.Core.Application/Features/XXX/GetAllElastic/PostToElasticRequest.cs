using Mediator;
using ZZ.Core.Application.Features.XXX.GetAllElastic;
using ZZ.Core.Domain.Dtos;

namespace ZZ.Core.Application.Features.XXX.GetAllElastic
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
