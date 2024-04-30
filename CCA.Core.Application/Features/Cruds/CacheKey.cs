using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Application.Features.Cruds
{
  internal static class CacheKey
  {
    static string _prefix => "Crud";
    public static string Key(int id) => $"{_prefix}-{id}";
  }
}
