using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZZ.XXX.Application.Interfaces.Infrastructure;
using ZZ.XXX.Application.Models.Emails;
using ZZ.XXX.Infrastructure.Emails;

namespace ZZ.XXX.Infrastructure.Config
{
  public static class EmailServiceConfig
  {
    public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection("EmailSettings");
      services.Configure<EmailSettings>(settings);
      services.AddTransient<ISendEmails, EmailService>();

      return services;
    }
  }
}
