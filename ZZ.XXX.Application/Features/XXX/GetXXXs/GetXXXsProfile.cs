using AutoMapper;
using ZZ.XXX.Domain.Entities;
using ZZ.XXX.Domain.Dtos;

namespace ZZ.XXX.Application.Features.XXX.GetXXXs
{
  public class GetXXXsProfile : Profile
  {
    public GetXXXsProfile()
    {
      CreateMap<XXXEntity, XXXDto>().ReverseMap();

    }
  }
}
