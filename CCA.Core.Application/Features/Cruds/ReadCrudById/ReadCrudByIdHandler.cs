using CCA.Core.Application.Features.Cruds.ReadCruds;
using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.Responses;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.ReadCrudById
{
  public class ReadCrudByIdHandler : IRequestHandler<ReadCrudByIdRequest, Result<Crud>>
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

    public async ValueTask<Result<Crud>> Handle(ReadCrudByIdRequest request, CancellationToken cancellationToken)
    {

      var validator = new ReadCrudByIdValidator();
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
      {
        return Result<Crud>.Fail(validationResult.Errors);
      }

      try
      {
        var entity = await _entities.Read(request.Id);
        if (entity == null)
        {
          // This is not a failure, because the Db call was successful, but the entity did not exist.
          return Result<Crud>.Ok(null);
        }

        var detail = await _details.Read(entity.Id);

        var crud = new Crud(entity, detail);

        return Result<Crud>.Ok(crud);

      }
      catch (Exception ex)
      {
        return Result<Crud>.Fail(ex);
      }
    }



  }
}
