using AutoMapper;
using Mediator;
using Microsoft.Extensions.Logging;
using ZZ.XXX.Application.Interfaces.Persistence;
using ZZ.XXX.Domain.Dtos.Elastic;

namespace ZZ.XXX.Application.Features.XXX.PostToElastic
{
  public class GetAllElasticHandler : IRequestHandler<GetAllElasticRequest, GetAllElasticResponse>
	{
		readonly IMapper _mapper;
		readonly IXXXElasticRepository _repo;
		readonly ILogger<GetAllElasticHandler> _logger;

		public GetAllElasticHandler(ILogger<GetAllElasticHandler> logger, IXXXElasticRepository repo, IMapper mapper)
		{
			_logger = logger;
			_repo = repo;
			_mapper = mapper;
		}

		public async ValueTask<GetAllElasticResponse> Handle(GetAllElasticRequest request, CancellationToken cancellationToken)
		{
      var results = await _repo.GetAll();

      return new GetAllElasticResponse(results);



		}
	}
}
