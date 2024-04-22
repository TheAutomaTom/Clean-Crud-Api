using AutoMapper;
using ZZ.Core.Domain.Dtos;
using ZZ.Core.Domain.Entities;

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
