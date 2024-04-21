using ZZ.XXX.Domain.Models.Emails;

namespace ZZ.XXX.Application.Interfaces.Infrastructure
{
  public interface ISendEmails
  {
    Task<bool> SendEmail(Email email);
  }
}
