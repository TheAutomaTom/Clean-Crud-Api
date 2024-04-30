using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Application.Interfaces.Persistence.Cruds;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.ReadCruds
{
  public class ReadCrudsHandler : IRequestHandler<ReadCrudsRequest, ReadCrudsResponse>
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

    public async ValueTask<ReadCrudsResponse> Handle(ReadCrudsRequest request, CancellationToken ct)
    {

      var validator = new ReadCrudsValidator();
      var validationResult = validator.Validate(request);

      if (validationResult.Errors.Count > 0)
      {
        return new ReadCrudsResponse() { ValidationErrors = validationResult.Errors };
      }

      try
      {
        var entities = await _entities.Read(request.Paging, request.UpdatedDateRange);
        if (!entities.Any())
        {
          throw new Exception("No entities found.");
        }


        var cruds = await _details.Read(entities);

        return new ReadCrudsResponse(cruds, request.Paging, request.UpdatedDateRange);

      }
      catch (Exception ex)
      {
        var response = new ReadCrudsResponse() { Exception = ex };
        return response;
      }
    }





  }
}
