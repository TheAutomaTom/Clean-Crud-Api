﻿using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.SearchParams;

namespace CCA.Core.Application.Features.Cruds.ReadCruds
{
	public class ReadCrudsResponse
  {
    public IEnumerable<Crud> Cruds {get; set;}
    public Paging? Paging {get; set;}
    public DateRangeFilter? UpdatedDateRange { get; set; }
		
		public ReadCrudsResponse(IEnumerable<Crud> cruds, Paging? paging, DateRangeFilter? updatedDateRange) : base()
    {
      Cruds = cruds;
    }
  }
}
