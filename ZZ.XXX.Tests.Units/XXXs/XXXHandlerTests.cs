using AutoMapper;
using Moq;
using ZZ.XXX.Application.Features;
using ZZ.XXX.Application.Features.XXX.GetXXXs;
using ZZ.XXX.Application.Interfaces.Persistence;
using ZZ.XXX.Domain.Entities;
using ZZ.XXX.Tests.Units.MockData;

namespace ZZ.XXX.Tests.Units.XXXs
{
  public class XXXHandlerTests
  {
    readonly IMapper _mapper;
    readonly Mock<IAsyncRepository<XXXEntity>> _repo;

    public XXXHandlerTests()
    {
      _repo = MockRepos.GetXXXRepository();
      var configurationProvider = new MapperConfiguration(cfg =>
      {
        cfg.AddProfile<GetXXXsProfile>();
      });

      _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async void GetXXXsTest()
    {
      var handler = new GetXXXsHandler(_mapper, _repo.Object);
      var result = await handler.Handle(new GetXXXsRequest(), CancellationToken.None);

      Assert.True(result.IsOk);
      Assert.True(result.XXXs != null);


    }
  }
}