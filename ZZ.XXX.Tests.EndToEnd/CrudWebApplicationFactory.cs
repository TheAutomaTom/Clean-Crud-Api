using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ZZ.Api;
using ZZ.Infra.Persistence.Repositories.DbContexts;

namespace ZZ.XXX.Tests.EndToEnd
{
  internal class CrudWebApplicationFactory : WebApplicationFactory<Program>
  {
    private readonly string _env;

    public CrudWebApplicationFactory(string environment = "Development")
    {
      _env = environment;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      builder.UseEnvironment("Development");
      var appsettingsPath = Directory.GetCurrentDirectory();

      var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{_env}.json", optional: true
        ).Build();

      builder.ConfigureTestServices(services =>
      {
        // Replace typical db connection string with Testcontainers instance 
        services.RemoveAll(typeof(DbContextOptions<CrudContext>));


        var sqlConnectionString = config.GetConnectionString("GeneralDb");
        services.AddSqlServer<CrudContext>(sqlConnectionString);

        // Refresh the mock Db every time.
        var crudContext = createCrudContext(services);
        crudContext.Database.EnsureDeleted(); // This ensure latest migration is implemented.




      });





    }

    static CrudContext createCrudContext(IServiceCollection services)
    {
      var provider = services.BuildServiceProvider();
      var scope = provider.CreateScope();
      var context = scope.ServiceProvider.GetRequiredService<CrudContext>();
      return context;
    }



  }
}
