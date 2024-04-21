using ZZ.XXX.Application.Models.Emails;

namespace ZZ.XXX.Application.Interfaces.Infrastructure
{
  public interface ISendEmails
  {
    Task<bool> SendEmail(Email email);
  }
}
