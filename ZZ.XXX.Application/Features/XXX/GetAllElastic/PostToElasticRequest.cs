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
