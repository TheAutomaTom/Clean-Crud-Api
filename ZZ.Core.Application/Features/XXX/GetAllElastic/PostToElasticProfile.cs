using AutoMapper;
using ZZ.Core.Domain.Dtos;
using ZZ.Core.Domain.Dtos.Elastic;

namespace ZZ.Core.Application.Features.XXX.GetAllElastic
{
  public class PostToElasticProfile : Profile
  {
    public PostToElasticProfile()
    {
      CreateMap<XXXEls, XXXDto>().ReverseMap();
    }
  }
}
