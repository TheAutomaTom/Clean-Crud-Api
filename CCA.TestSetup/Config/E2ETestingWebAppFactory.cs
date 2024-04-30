using CCA.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace CCA.TestSetup.Config
{
  public class E2ETestingWebAppFactory : WebApplicationFactory<Program>
  {
    readonly string _env;
    public E2ETestingWebAppFactory(string env = "Test")
    {
      _env = env;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      base.ConfigureWebHost(builder);

      builder.ConfigureTestServices(services =>
      {
        // Override typical behavior here...
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", _env);

      });
    }


  }
}
