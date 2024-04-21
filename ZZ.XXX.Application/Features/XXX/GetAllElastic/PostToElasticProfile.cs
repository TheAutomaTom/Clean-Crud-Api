using AutoMapper;
using ZZ.XXX.Domain.Dtos;
using ZZ.XXX.Domain.Dtos.Elastic;
using ZZ.XXX.Application.Features.XXX.PostToElastic;

namespace ZZ.XXX.Application.Features.XXX.GetAllElastic
{
  public class PostToElasticProfile : Profile
  {
    public PostToElasticProfile()
    {
      CreateMap<XXXEls, XXXDto>().ReverseMap();
    }
  }
}
