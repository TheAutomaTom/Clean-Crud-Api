using AutoMapper;
using Mediator;
using Whether_Advisory.XXX.Application.Interfaces.Persistence;
using Whether_Advisory.XXX.Domain.Entities;
using Whether_Advisory.XXX.Domain.Dtos;

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
      var validator = new GetXXXsValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);
      if(!validationResult.IsValid)
      {
        var messages = validationResult.Errors.Select(e => e.ErrorMessage);
        return new GetXXXsResponse(messages);
      }

      var xxxs = await _repository.ListAllAsync();
      var mapped = _mapper.Map<IEnumerable<XXXDto>>(xxxs);
      return new GetXXXsResponse(mapped);
    }
  }
}
