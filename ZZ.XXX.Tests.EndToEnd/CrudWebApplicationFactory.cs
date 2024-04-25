using System.Reflection;
using System.Xml;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.MsSql;
using ZZ.Api;
using ZZ.Infra.Persistence.Repositories.DbContexts;
using ZZ.XXX.Tests.EndToEnd.Config;

namespace ZZ.XXX.Tests.EndToEnd
{
  internal class CrudWebApplicationFactory : WebApplicationFactory<Program>
  {
    readonly string _env;
    public static MsSqlContainer _msSqlContainer
        = new MsSqlBuilder().WithName($"MockMsSql_{DateTime.Now.ToString("yyMMddHmmss")}").Build();

    public CrudWebApplicationFactory(string environment = "Test")
    {
      _env = environment;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      /* Testcontainers Setup */
      // Launch Testcontainers' mock MsSql Server.
      var launchContainerTask = _msSqlContainer.StartAsync();
      launchContainerTask.Wait();
      // Detect its random address, and rewrite AppSettings.test file before HostBuilder reads it.
      var testContainerConnectionString = _msSqlContainer.GetConnectionString();
      var settingsFixer = new AppSettingsWriter(_getProjectDirectory);
      settingsFixer.AddOrUpdateAppSetting("Test", "GeneralDb", testContainerConnectionString);

      /* Test Server Setup */
      var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{_env}.json", optional: true, reloadOnChange: true
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



    static string _getProjectDirectory
    {
      get
      {
        var codeBase = Assembly.GetExecutingAssembly().Location;
        var uri = new UriBuilder(codeBase);
        var root = Uri.UnescapeDataString(uri.Path);
        var assembly = Path.GetDirectoryName(root);
        return $@"{assembly}..\..\..\..\..\{Assembly.GetCallingAssembly().GetName().Name}";
      }
    }
  }
}
