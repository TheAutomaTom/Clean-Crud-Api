using AutoMapper;
using ZZ.Core.Domain._Deprecated;
using ZZ.Core.Domain._Deprecated.Elastic;

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
