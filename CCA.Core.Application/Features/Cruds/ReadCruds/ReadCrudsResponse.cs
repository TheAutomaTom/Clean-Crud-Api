using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.Search;
using CCA.Core.Infra.Models.Responses;
using CCA.Core.Infra.Models.Results;

namespace CCA.Core.Application.Features.Cruds.ReadCruds
{
  public class ReadCrudsResponse : Result
  {
    public ReadCrudsResponse() : base()
    {
      
    }

    public ReadCrudsResponse(Error error ) : base(error)
    {
      
    }

    public ReadCrudsResponse(Exception ex ) : base(ex)
    {
      
    }

    public ReadCrudsResponse(IEnumerable<Crud> cruds, Paging? paging, DateRangeFilter? updatedDateRange) : base()
    {
      Cruds = cruds;

    }

      public IEnumerable<Crud> Cruds {get; set;}
      public Paging? Paging {get; set;}
      public DateRangeFilter? UpdatedDateRange { get; set; }
  }
}
