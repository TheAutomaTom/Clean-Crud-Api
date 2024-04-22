//using AutoMapper;
//using Moq;
//using ZZ.XXX.Tests.Units.MockData;
//using ZZ.Core.Application.Features.XXX.GetXXXs;
//using ZZ.Core.Application.Interfaces.Persistence;
//using ZZ.Core.Domain._Deprecated;

//namespace ZZ.XXX.Tests.Units.XXXs
//{
//  public class XXXHandlerTests
//  {
//    readonly IMapper _mapper;
//    readonly Mock<IAsyncRepository<XXXEntity>> _repo;

//    public XXXHandlerTests()
//    {
//      _repo = MockRepos.GetXXXRepository();
//      var configurationProvider = new MapperConfiguration(cfg =>
//      {
//        cfg.AddProfile<GetXXXsProfile>();
//      });

//      _mapper = configurationProvider.CreateMapper();
//    }

//    [Fact]
//    public async void GetXXXsTest()
//    {
//      var handler = new GetXXXsHandler(_mapper, _repo.Object);
//      var result = await handler.Handle(new GetXXXsRequest(), CancellationToken.None);

//      Assert.True(result.IsOk);
//      Assert.True(result.XXXs != null);


//    }
//  }
//}