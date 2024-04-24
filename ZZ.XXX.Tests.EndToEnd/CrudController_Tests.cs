using System.Net.Http.Json;
using ZZ.Core.Application.Features.Cruds.CreateCrud;
using static ZZ.XXX.Tests.EndToEnd.Mocks.BogusGenerators;

namespace ZZ.XXX.Tests.EndToEnd
{
  public class CrudController_Tests
  {


    [Fact]
    public async Task CreateCrud_IsOk()
    {
      /* Arrange */
      // Load server into memory
      var app = new CrudWebApplicationFactory();

      // Create client to send request to api
      var client = app.CreateClient();

      // Generate request body
      var fake = CrudFaker.Generate().First();
      var request = new CreateCrudRequest
      {
        Name = fake.Name,
        Department = fake.Department,
        Description = fake.Detail.Description,
        Tags = fake.Detail.Tags
      };

      /* Act */
      var response = await client.PostAsJsonAsync("/crud/create", request);

      /* Assert */
      Assert.True(response.IsSuccessStatusCode);

      var result = await response.Content.ReadFromJsonAsync<CreateCrudResponse>();
      Assert.True(result.IsOk);
      Assert.NotNull(result.Crud);
      Assert.False(result.Crud.Id == 0);



    }
  }
}
