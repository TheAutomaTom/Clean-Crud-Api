using Microsoft.Extensions.Options;
using ZZ.Core.Application.Interfaces.Infrastructure;
using ZZ.Core.Plumbing.Models.Emails;

namespace ZZ.Infra.Services.Emails
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
