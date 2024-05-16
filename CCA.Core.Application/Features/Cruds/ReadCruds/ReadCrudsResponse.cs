using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.Search;
using CCA.Core.Infra.Models.Responses;
using CCA.Core.Infra.Models.Results;
using FluentValidation.Results;

namespace CCA.Core.Application.Features.Cruds.ReadCruds
{
  public class ReadCrudsResponse : Result
  {
    public IEnumerable<Crud> Cruds {get; set;}
    public Paging? Paging {get; set;}
    public DateRangeFilter? UpdatedDateRange { get; set; }
		
		public ReadCrudsResponse(IEnumerable<Crud> cruds, Paging? paging, DateRangeFilter? updatedDateRange) : base()
    {
      Cruds = cruds;
    }
    
		/// <summary>
		/// This is way to much redundant code.  I should proably make an object containing the 3 properties, then use Result<T>.
		/// </summary>
		public ReadCrudsResponse() : base()    {    }
    public ReadCrudsResponse(IEnumerable<ValidationFailure> validationErrors) : base(validationErrors)    {    }
    public ReadCrudsResponse(ExpectedError error ) : base(error)    {    }
    public ReadCrudsResponse(Exception ex ) : base(ex)    {    }
  }
}
