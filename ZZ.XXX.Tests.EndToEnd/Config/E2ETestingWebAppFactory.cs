using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using ZZ.Api;

namespace E2E.Tests.Integration.Api_to_Testcontainer_Tests
{
  public class E2ETestingWebAppFactory : WebApplicationFactory<Program>
  {

    public E2ETestingWebAppFactory()
    {

    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      base.ConfigureWebHost(builder);

      builder.ConfigureTestServices(services =>
      {
        // Override typical behavior here...
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");

      });
    }


  }
}
