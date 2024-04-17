using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZ.XXX.Application.Models.Emails;

namespace ZZ.XXX.Application.Interfaces.Infrastructure
{
  public interface ISendEmails
  {
    Task<bool> SendEmail(Email email);
  }
}
