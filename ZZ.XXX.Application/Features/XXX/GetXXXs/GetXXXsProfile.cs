using AutoMapper;
using Whether_Advisory.XXX.Domain.Entities;
using Whether_Advisory.XXX.Domain.Dtos;

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
