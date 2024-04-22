using AutoMapper;
using Mediator;
using ZZ.Core.Application.Features.XXX.GetXXXs;
using ZZ.Core.Application.Interfaces.Persistence;
using ZZ.Core.Domain._Deprecated;

namespace ZZ.Core.Application.Features.XXX.GetXXXs
{
  public class GetXXXsHandler : IRequestHandler<GetXXXsRequest, GetXXXsResponse>
  {
    //private readonly ILogger<GetXXXsHandler> _logger;
    readonly IAsyncRepository<XXXEntity> _repository;
    readonly IMapper _mapper;

    public GetXXXsHandler(IMapper mapper, IAsyncRepository<XXXEntity> repository)//ILogger<GetXXXsHandler> _logger)
    {
      _mapper = mapper;
      _repository = repository;

    }

    public async ValueTask<GetXXXsResponse> Handle(GetXXXsRequest request, CancellationToken cancellationToken)
    {

      try
      {
        var xxxs = await _repository.ReadAll();
        var mapped = _mapper.Map<IEnumerable<XXXDto>>(xxxs);

        return new GetXXXsResponse(mapped);

      }
      catch (Exception ex)
      {
        return new GetXXXsResponse(null) { Exception = ex };
      }




    }



  }
}
