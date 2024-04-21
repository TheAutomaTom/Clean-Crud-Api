using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZZ.XXX.Application.Interfaces.Infrastructure;
using ZZ.XXX.Infrastructure.Emails;
using ZZ.XXX.Domain.Models.Emails;

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
