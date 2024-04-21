using Mediator;
using ZZ.XXX.Domain.Dtos;
using ZZ.XXX.Application.Features.XXX.PostToElastic;
using ZZ.XXX.Application.Features.XXX.GetAllElastic;

namespace ZZ.XXX.Application.Features.XXX.GetAllElastic
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
