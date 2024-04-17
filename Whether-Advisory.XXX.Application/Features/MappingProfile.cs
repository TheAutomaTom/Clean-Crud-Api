using AutoMapper;
using Whether_Advisory.XXX.Application.Features.XXX.GetXXXs;

namespace Whether_Advisory.XXX.Application.Features
{
  public static class MappingProfile
  {
    public static MapperConfiguration InitAutoMapper()
    {
      MapperConfiguration config = new MapperConfiguration(cfg =>
      {
        cfg.AddProfile(new GetXXXsProfile());


      });

      return config;
    }
  }
}
