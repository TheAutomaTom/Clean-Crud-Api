using AutoMapper;
using Whether_Advisory.XXX.Application.Features.XXX.GetXXXs;

namespace WA.CMS.Application
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
