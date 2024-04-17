using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZZ.XXX.Application.Interfaces.Infrastructure;
using ZZ.XXX.Application.Interfaces.Persistence;
using ZZ.XXX.Application.Models.Emails;
using ZZ.XXX.Infrastructure.Emails;

namespace ZZ.XXX.Data.Config
{
  public static class InfrastructureDI
  {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection("EmailSettings");
      services.Configure<EmailSettings>(settings);
      services.AddTransient<ISendEmails, EmailService>();

      return services;
    }
  }
}
