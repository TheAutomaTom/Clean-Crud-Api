using System;
using System.Security;
using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Core.Domain.Models.Cruds;
using CCA.Data.Persistence.Cache;
using CCA.Tests.EndToEnd.Config;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MsSql;
using static CCA.Tests.EndToEnd.Mock.BogusGenerators;

namespace CCA.Tests.EndToEnd.Tests
{
  public class Test_Connectivity
  {
    /* Lifecycle.....................................................*/

    E2ETestingWebAppFactory _factory;
    //MsSqlContainer _msSqlContainer;
    //HttpClient _client;
    Random _rando = new Random();

    public Test_Connectivity()
    {

      // This ctor sets the environment variable.
      _factory = new E2ETestingWebAppFactory();

      //_msSqlContainer = new MsSqlBuilder().Build();
      //_msSqlContainer.StartAsync().Wait();

      //var cs = _msSqlContainer.GetConnectionString();
      //Environment.SetEnvironmentVariable("GeneralDb-Testing", cs);

      //_client = _factory.CreateClient();
    }

    public void Dispose()
    {
      _factory.Dispose();
    }

    /* ...lifecycle``````````````````````````````````````````````````*/


    [Fact]
    public async Task DistributedCache_IsOk() 
    {
      var service = _factory.Services.GetService<ICache>() as CacheService;

      // TODO: Parse service.GetStatus() for health check.
      var isConnected = service.GetStatus();
            
      var key1 = $"TestString-{_rando.Next(1, 999)}";
      var value1 = Guid.NewGuid().ToString();

      var isCachingStrings = await service.Create(key1, value1);
      Assert.True(isCachingStrings.IsOk);

      var isReadingStrings = await service.ReadString(key1);
      Assert.True(isReadingStrings.IsOk);
      Assert.Equal(value1, isReadingStrings.Data);


      var key2 = $"TestString-{_rando.Next(1, 999)}";
      var value2 = CrudFaker.Generate().First();
      
      var isCachingObjects = await service.Create<Crud>(key2, value2);
      Assert.True(isCachingObjects.IsOk);

      var isReadingObjects = await service.Read<Crud>(key2);
      Assert.True(isReadingObjects.IsOk);
      Assert.Equal(value2.Id, isReadingObjects.Data.Id);
      Assert.Equal(value2.Name, isReadingObjects.Data.Name);
      Assert.Equal(value2.Detail.Id, isReadingObjects.Data.Detail.Id);
      Assert.Equal(value2.Detail.Tags, isReadingObjects.Data.Detail.Tags);









    }












  }
}

