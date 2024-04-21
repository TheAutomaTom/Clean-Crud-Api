using AutoMapper;
using ZZ.XXX.Domain.Dtos;
using ZZ.XXX.Domain.Dtos.Elastic;

namespace ZZ.XXX.Application.Features.XXX.PostToElastic
{
  public class PostToElasticProfile : Profile
  {
    public PostToElasticProfile()
    {
      CreateMap<XXXEls, XXXDto>().ReverseMap();
    }
  }
}
