using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Infra.Models.Search
{
  public class DateRange
  {
    public DateRange(DateTime? from, DateTime? until)
    {
      From = from ?? DateTime.MinValue;
      Until = until ?? DateTime.MaxValue;
    }
    public DateTime From { get; set; }
    public DateTime Until { get; set; }
  }
}
