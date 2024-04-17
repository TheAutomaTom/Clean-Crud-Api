using AutoMapper;
using Mediator;
using ZZ.XXX.Application.Interfaces.Persistence;
using ZZ.XXX.Domain.Common.Responses;
using ZZ.XXX.Domain.Dtos;
using ZZ.XXX.Domain.Entities;

namespace ZZ.XXX.Application.Features.XXX.GetXXXs
{
  public class GetXXXsHandler : IRequestHandler<GetXXXsRequest, BasicResponse<IEnumerable<XXXDto>> >
  {
    //private readonly ILogger<GetXXXsHandler> _logger;
    readonly IAsyncRepository<XXXEntity> _repository;
    readonly IMapper _mapper;

    public GetXXXsHandler( IMapper mapper, IAsyncRepository<XXXEntity> repository )//ILogger<GetXXXsHandler> _logger)
    {
      _mapper = mapper;
      _repository = repository;
      
    }

    public async  ValueTask<BasicResponse<IEnumerable<XXXDto>>> Handle(GetXXXsRequest request, CancellationToken cancellationToken)
    {
      var validator = new GetXXXsValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);
      if(!validationResult.IsValid)
      {
        return new BasicResponse<IEnumerable<XXXDto>>().Fail(validationResult.Errors);
      }

      var xxxs = await _repository.ListAllAsync();
      var mapped = _mapper.Map<IEnumerable<XXXDto>>(xxxs);

      return new BasicResponse<IEnumerable<XXXDto>>(mapped).Ok();




    }



  }
}
