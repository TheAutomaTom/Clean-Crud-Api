using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Testcontainers.MsSql;
using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Tests.EndToEnd.Config;
using static CCA.Tests.EndToEnd.Mock.BogusGenerators;

namespace CCA.Tests.EndToEnd.Tests
{
  public class CrudController_Tests : IDisposable
  {
    E2ETestingWebAppFactory _factory;
    HttpClient _client;
    MsSqlContainer _msSqlContainer;
    Random _rando = new Random();

    public CrudController_Tests()
    {

      // This ctor sets the environment variable.
      _factory = new E2ETestingWebAppFactory();


      _msSqlContainer = new MsSqlBuilder().Build();
      _msSqlContainer.StartAsync().Wait();

      var cs = _msSqlContainer.GetConnectionString();
      Environment.SetEnvironmentVariable("GeneralDb-Testing", cs);

      _client = _factory.CreateClient();
    }
    public void Dispose()
    {
      _factory.Dispose();
      _client.Dispose();
    }

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

      var result = await response.Content.ReadFromJsonAsync<CreateCrudResponse>();
      Assert.NotNull(result);
      Assert.True(result.IsOk);

      Assert.NotNull(result.Crud);
      Assert.True(result.Crud.Id > 0);



    }



  }
}
