using CCA.Core.Application.Interfaces.Persistence.Cruds;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Infra.Models.Responses;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.ReadCrudById
{
  public class ReadCrudByIdHandler : IRequestHandler<ReadCrudByIdRequest, Result<Crud>>
  {
    readonly IManageCrudDetails _details;
    readonly IManageCrudEntities _entities;
    readonly ILogger<ReadCrudByIdHandler> _logger;

    public ReadCrudByIdHandler(ILogger<ReadCrudByIdHandler> logger, IManageCrudEntities entities, IManageCrudDetails details)
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
          // TODO: Think about another way to handle this.
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
