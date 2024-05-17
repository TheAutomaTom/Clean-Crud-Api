using Mediator;
using CCA.Core.Infra.Models.Search;
using CCA.Core.Infra.Models.Responses;

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
