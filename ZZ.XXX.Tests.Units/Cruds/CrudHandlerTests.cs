using Mediator;
using Microsoft.Extensions.Logging;
using Moq;
using ZZ.Core.Application.Features.Cruds.CreateCrud;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.XXX.Tests.Units.MockData;

namespace ZZ.XXX.Tests.Units.XXXs
{
  public class CrudHandlerTests
  {
    readonly Mock<ICrudRepository> _repoE;
    readonly Mock<ICrudDetailRepository> _repoD;

    public CrudHandlerTests()
    {
      _repoE = MockRepos.MockCrudRepository();
      _repoD = MockRepos.MockCrudDetailRepository(_repoE);
      //var configurationProvider = new MapperConfiguration(cfg =>
      //{
      //  cfg.AddProfile<>();
      //});
      //_mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async void Test_CreateCrud_IsOk()
    {

      var logger = Mock.Of<ILogger<CreateCrudHandler>>();


      var handler = new CreateCrudHandler(logger, _repoE.Object, _repoD.Object);
      var result = await handler.Handle(new CreateCrudRequest(), CancellationToken.None);

      Assert.True(result.IsOk)
        ;
      Assert.True(result.IsOk);
      Assert.True(result.Crud != null);
      Assert.True(result.Crud?.Id != 0);


    }
  }
}