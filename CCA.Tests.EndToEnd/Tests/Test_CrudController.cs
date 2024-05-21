using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.ResultTypes;
using CCA.TestSetup.Config;
using Testcontainers.MsSql;
using Testcontainers.Redis;
using static CCA.TestSetup.MockData.BogusGenerators;

namespace CCA.Tests.EndToEnd.Tests
{
	public class Test_CrudController : IDisposable
  {
    /* Lifecycle.....................................................*/

    E2ETestingWebAppFactory _factory;
		readonly RedisContainer _redisContainer;
		HttpClient _client;
    MsSqlContainer _msSqlContainer;
    Random _rando = new Random();

    public Test_CrudController()
    {

      // This ctor sets the environment variable.
      _factory = new E2ETestingWebAppFactory();

			_redisContainer = new RedisBuilder().Build();
			_redisContainer.StartAsync().Wait();
			var cacheCs = _redisContainer.GetConnectionString();
			Environment.SetEnvironmentVariable("RedisCache-Testing", cacheCs);

			_msSqlContainer = new MsSqlBuilder().Build();
      _msSqlContainer.StartAsync().Wait();

      var msSqlCs = _msSqlContainer.GetConnectionString();
      Environment.SetEnvironmentVariable("GeneralDb-Testing", msSqlCs);

      _client = _factory.CreateClient();
    }

    public void Dispose()
    {
      _factory.Dispose();
      _client.Dispose();
    }

    /* ...lifecycle ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^*/

    [Fact]
    public async Task CreateCrud_IsOk()
    {
      /* Arrange */

      // Generate request body
      var fake = CrudFaker.Generate().First();
      var requestBody = new CreateCrudRequest
      {
        Name = fake.Name,
        Department = fake.Department,
        Description = fake.Detail.Description,
        Tags = fake.Detail.Tags
      };

      var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

      /* Act */
      var response = await _client.PostAsync("/crud/create", jsonContent);



      response.EnsureSuccessStatusCode();

      var content = await response.Content.ReadAsStringAsync();


      /* Assert */
      Assert.True(response.IsSuccessStatusCode);

      var result = await response.Content.ReadFromJsonAsync<Result<Crud>>();
      Assert.NotNull(result);
      Assert.True(result.IsOk == true);

      Assert.NotNull(result.Data);
      Assert.True(result.Data.Id > 0);
      Assert.True(result.Data.Detail.Id > 0);



    }



  }
}
