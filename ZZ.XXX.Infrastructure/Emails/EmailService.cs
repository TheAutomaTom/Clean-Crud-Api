using Microsoft.Extensions.Options;
using ZZ.XXX.Application.Interfaces.Infrastructure;
using ZZ.XXX.Application.Models.Emails;

namespace ZZ.XXX.Infrastructure.Emails
{
  public class EmailService : ISendEmails
  {
    public EmailSettings Settings { get; }

    public EmailService(IOptions<EmailSettings> settings)
    {
      Settings = settings.Value;
    }

    public Task<bool> SendEmail(Email email)
    {
      throw new NotImplementedException();
    }
  }
}
