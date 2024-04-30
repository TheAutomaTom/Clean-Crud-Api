using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Core.Application.Interfaces.Persistence.Cruds;
using CCA.Core.Infra.Models.Responses;
using CCA.Core.Infra.Models.Results;
using FluentValidation.Results;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.DeleteCrudById
{
  public class DeleteCrudByIdHandler : IRequestHandler<DeleteCrudByIdRequest, Result>
  {
    readonly IManageCrudDetails _details;
    readonly IManageCrudEntities _entities;
    readonly ILogger<DeleteCrudByIdHandler> _logger;

    public DeleteCrudByIdHandler(ILogger<DeleteCrudByIdHandler> logger, IManageCrudEntities entities, IManageCrudDetails details)
    {
      _logger = logger;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<Result> Handle(DeleteCrudByIdRequest request, CancellationToken cancellationToken)
    {
      var validator = new DeleteCrudByIdValidator();
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
      {
        return Result.Fail(validationResult.Errors);
      }

      try
      {
        var errors = new List<Error>();

        var entityAttempt = await _entities.Delete(request.Id);
        if (entityAttempt == 0)
        {
          errors.Add( new Error("DeleteCrudByIdHandler", $"{nameof(_entities)} Failed to delete entity ID# {request.Id}."));
        }

        var detailAttempt = await _details.Delete(request.Id);
        if (detailAttempt == 0)
        {
          errors.Add(new Error("DeleteCrudByIdHandler", $"{nameof(_details)} Failed to delete detail ID# {request.Id}."));
          
        }

        if (errors.Any())
        {
          return Result.Fail(errors);
        }

        return Result.Ok();

      }
      catch (Exception ex)
      {
        return Result.Fail(ex);
      }
    }





  }
}

