using Mediator;
using CCA.Core.Infra.Models.Search;

namespace CCA.Core.Application.Features.Cruds.ReadCruds
{
  public class ReadCrudsRequest : IRequest<ReadCrudsResponse>
  {
    public ReadCrudsRequest(Paging? paging, DateRange? updatedRange)
    {
      Paging = paging;
      UpdatedDateRange = updatedRange;
    }
    public Paging? Paging { get; set; }
    public DateRange? UpdatedDateRange { get; set; }
  }
}
