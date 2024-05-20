using Mediator;
using CCA.Core.Infra.Models.SearchParams;
using CCA.Core.Infra.ResultTypes;

namespace CCA.Core.Application.Features.Cruds.ReadCruds
{
	public class ReadCrudsRequest : IRequest<Result<ReadCrudsResponse>>
  {
    public ReadCrudsRequest(Paging? paging, DateRangeFilter? updatedRange)
    {
      Paging = paging;
      UpdatedDateRange = updatedRange;
    }
    public Paging? Paging { get; set; }
    public DateRangeFilter? UpdatedDateRange { get; set; }
  }
}
