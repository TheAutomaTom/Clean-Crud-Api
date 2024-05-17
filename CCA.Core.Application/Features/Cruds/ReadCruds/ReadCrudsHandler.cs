using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Application.Interfaces.Persistence.Cruds;
using CCA.Core.Infra.Models.Responses;
using CCA.Core.Infra.Models.Results;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.ReadCruds
{
  public class ReadCrudsHandler : IRequestHandler<ReadCrudsRequest, Result<ReadCrudsResponse>>
  {
    readonly ICrudDetailsRepository _details;
    readonly ICrudEntitiesRepository _entities;
    readonly ILogger<ReadCrudsHandler> _logger;

    public ReadCrudsHandler(ILogger<ReadCrudsHandler> logger, ICrudEntitiesRepository entities, ICrudDetailsRepository details)
    {
      _logger = logger;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<Result<ReadCrudsResponse>> Handle(ReadCrudsRequest request, CancellationToken ct)
    {

      var validator = new ReadCrudsValidator();
      var validationResult = validator.Validate(request);

      if (validationResult.Errors.Count > 0)
      {
        return new Result<ReadCrudsResponse> (validationResult.Errors);
      }

      try
      {
        var entities = await _entities.Read(request.Paging, request.UpdatedDateRange);
        if (!entities.Any())
        {
          return new Result<ReadCrudsResponse>(new ExpectedError(ErrorCode.Connectivity));
        }


        var cruds = await _details.Read(entities);

        return new Result<ReadCrudsResponse>(new ReadCrudsResponse(cruds, request.Paging, request.UpdatedDateRange));

      }
      catch (Exception ex)
      {
				var response = new Result<ReadCrudsResponse>(ex);
        return response;
      }
    }





  }
}
