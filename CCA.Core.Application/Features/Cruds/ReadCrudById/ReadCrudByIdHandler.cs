using CCA.Core.Application.Features.Cruds.ReadCruds;
using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.ReadCrudById
{
  public class ReadCrudByIdHandler : IRequestHandler<ReadCrudByIdRequest, ReadCrudByIdResponse>
  {
    readonly ICrudDetailRepository _details;
    readonly ICrudRepository _entities;
    readonly ILogger<ReadCrudByIdHandler> _logger;
    public ReadCrudByIdHandler(ILogger<ReadCrudByIdHandler> logger, ICrudRepository entities, ICrudDetailRepository details)
    {
      _logger = logger;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<ReadCrudByIdResponse> Handle(ReadCrudByIdRequest request, CancellationToken cancellationToken)
    {

      var validator = new ReadCrudByIdValidator();
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
      {
        return new ReadCrudByIdResponse() { ValidationErrors = validationResult.Errors };
      }

      try
      {
        var entity = await _entities.Read(request.Id);
        if (entity == null)
        {
          throw new Exception("No entity found.");
        }

        var detail = await _details.Read(entity.Id);

        var crud = new Crud(entity, detail);

        return new ReadCrudByIdResponse(crud);

      }
      catch (Exception ex)
      {
        var response = new ReadCrudByIdResponse() { Exception = ex };
        return response;
      }
    }



  }
}
