using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.HtmlRendering.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ZZ.Api;
using ZZ.Infra.Persistence.Repositories.DbContexts;

namespace ZZ.XXX.Tests.EndToEnd.Config
{
  internal class CrudWebApplicationFactory : WebApplicationFactory<Program>
  {
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
      var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
        .Build();

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
