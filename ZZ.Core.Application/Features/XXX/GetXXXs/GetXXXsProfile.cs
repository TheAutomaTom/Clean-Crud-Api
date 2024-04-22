using AutoMapper;
using ZZ.Core.Domain._Deprecated;

namespace ZZ.Core.Application.Features.XXX.GetXXXs
{
  public class GetXXXsProfile : Profile
  {
    public GetXXXsProfile()
    {
      CreateMap<XXXEntity, XXXDto>().ReverseMap();

    }
  }
}
