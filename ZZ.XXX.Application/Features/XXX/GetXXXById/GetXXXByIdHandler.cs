using ZZ.XXX.Domain.Entities;
using ZZ.XXX.Domain.Dtos;
using ZZ.XXX.Domain.Common.Responses;
using ZZ.XXX.Application.Interfaces.Persistence;
using Mediator;
using AutoMapper;
using System.Threading;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ZZ.XXX.Application.Features.XXX.GetXXXById
{
  public class GetXXXByIdHandler : IRequestHandler<GetXXXByIdRequest, GetXXXByIdResponse>
  {
    readonly IMapper _mapper;
    readonly IAsyncRepository<XXXEntity> _repo;
    readonly ILogger<GetXXXByIdHandler> _logger;

    public GetXXXByIdHandler(ILogger<GetXXXByIdHandler> logger, IAsyncRepository<XXXEntity> repo, IMapper mapper)
    {
			_logger = logger;
			_repo = repo;
			_mapper = mapper;
    }

    public async ValueTask<GetXXXByIdResponse> Handle(GetXXXByIdRequest request, CancellationToken ct)
    {
			throw new NotImplementedException();
    }
  }
}
