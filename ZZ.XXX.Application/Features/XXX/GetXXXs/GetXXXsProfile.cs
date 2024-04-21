using AutoMapper;
using ZZ.XXX.Domain.Dtos;
using ZZ.XXX.Domain.Entities;

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
