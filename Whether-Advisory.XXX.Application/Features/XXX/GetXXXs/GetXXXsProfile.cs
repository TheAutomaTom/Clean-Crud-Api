using AutoMapper;
using Whether_Advisory.XXX.Domain.DTOs;
using Whether_Advisory.XXX.Domain.Entities;

namespace Whether_Advisory.XXX.Application.Features.XXX.GetXXXs
{
  public class GetXXXsProfile : Profile
  {
    public GetXXXsProfile()
    {
      CreateMap<XXXEntity, XXXDto>().ReverseMap();

    }
  }
}
