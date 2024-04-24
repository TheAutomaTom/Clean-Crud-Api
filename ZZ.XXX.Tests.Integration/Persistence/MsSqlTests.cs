using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace ZZ.XXX.Tests.Integration.Persistence
{
  public sealed class MsSqlTests : IAsyncLifetime
  {
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder().Build();

    public Task InitializeAsync()
    {
      return _msSqlContainer.StartAsync();
    }

    public Task DisposeAsync()
    {
      return _msSqlContainer.DisposeAsync().AsTask();
    }

    public sealed class IndexPageTests : IClassFixture<MsSqlTests>, IDisposable
    {
      private readonly WebApplicationFactory<Program> _webApplicationFactory;

      private readonly HttpClient _httpClient;

      public IndexPageTests(MsSqlTests fixture)
      {
        var clientOptions = new WebApplicationFactoryClientOptions();
        clientOptions.AllowAutoRedirect = false;

        _webApplicationFactory = new CustomWebApplicationFactory(fixture);
        _httpClient = _webApplicationFactory.CreateClient(clientOptions);
      }

      public void Dispose()
      {
        _webApplicationFactory.Dispose();
      }

      private sealed class CustomWebApplicationFactory : WebApplicationFactory<Program>
      {
        private readonly string _connectionString;

        public CustomWebApplicationFactory(MsSqlTests fixture)
        {
          _connectionString = fixture._msSqlContainer.GetConnectionString();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
          builder.ConfigureServices(services =>
          {
            services.Remove(services.SingleOrDefault(service => typeof(DbContextOptions<ApplicationDbContext>) == service.ServiceType));
            services.Remove(services.SingleOrDefault(service => typeof(DbConnection) == service.ServiceType));
            services.AddDbContext<ApplicationDbContext>((_, option) => option.UseSqlServer(_connectionString));
          });
        }
      }
    }
  }