using AutoMapper;
using Mediator;
using Microsoft.Extensions.Logging;
using ZZ.XXX.Application.Interfaces.Persistence;
using ZZ.XXX.Domain.Entities;

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
