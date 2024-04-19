using AutoMapper;
using ZZ.XXX.Application.Features.XXX.GetXXXs;

namespace ZZ.XXX.Application.Features
{
  public class MappingProfile : Profile
  {
    public MapperConfiguration InitAutoMapper()
    {
      MapperConfiguration config = new MapperConfiguration(cfg =>
      {
        cfg.AddProfile(new GetXXXsProfile());


      });

      return config;
    }
  }
}
