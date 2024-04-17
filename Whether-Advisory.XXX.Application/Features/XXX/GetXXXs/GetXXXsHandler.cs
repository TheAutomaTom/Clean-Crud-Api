using AutoMapper;
using Mediator;
using Whether_Advisory.XXX.Application.Interfaces.Persistence;
using Whether_Advisory.XXX.Domain.DTOs;
using Whether_Advisory.XXX.Domain.Entities;

namespace Whether_Advisory.XXX.Application.Features.XXX.GetXXXs
{
  public class GetXXXsHandler : IRequestHandler<GetXXXsRequest, GetXXXsResponse>
  {
    //private readonly ILogger<GetXXXsHandler> _logger;
    readonly IAsyncRepository<XXXEntity> _repository;
    readonly IMapper _mapper;

    public GetXXXsHandler( IMapper mapper, IAsyncRepository<XXXEntity> repository )//ILogger<GetXXXsHandler> _logger)
    {
      _mapper = mapper;
      _repository = repository;
      
    }

    public async  ValueTask<GetXXXsResponse> Handle(GetXXXsRequest request, CancellationToken cancellationToken)
    {
      var xxxs = await _repository.ListAllAsync();
      var mapped = _mapper.Map<IEnumerable<XXXDto>>(xxxs);
      return new GetXXXsResponse(mapped);
    }
  }
}
