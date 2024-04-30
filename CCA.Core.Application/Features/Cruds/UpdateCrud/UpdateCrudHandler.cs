using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Application.Interfaces.Persistence.Cruds;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Responses;
using CCA.Core.Infra.Models.Results;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.UpdateCrud
{
  public class UpdateCrudHandler : IRequestHandler<UpdateCrudRequest, Result<Crud>>
  {
    readonly IManageCrudDetails _details;
    readonly IManageCrudEntities _entities;
    readonly ILogger<UpdateCrudHandler> _logger;

    public UpdateCrudHandler(ILogger<UpdateCrudHandler> logger, IManageCrudEntities entities, IManageCrudDetails details)
    {
      _logger = logger;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<Result<Crud>> Handle(UpdateCrudRequest request, CancellationToken cancellationToken)
    {
      // Validate request
      var validator = new UpdateCrudValidator();
      var validationResult = await validator.ValidateAsync(request);
      if (validationResult.Errors.Count > 0)
      {
        return Result<Crud>.Fail(validationResult.Errors);
      }


      // Attempt process
      try
      {

        var toUpdate = new Crud()
        {
          Id = request.Id,
          Name = request.Name,
          Department = request.Department,
          Detail = new CrudDetail()
          {
            Id = request.Id,
            Description = request.Description,
            Tags = request.Tags
          }

        };

        var entityUpdate = await _entities.Update(toUpdate);
        if (!entityUpdate)
        {
          return Result<Crud>.Fail(new Error("UpdateCrudHandler",CommonError.DoesNotExist.ToString()));
        }

        var detailUpdate = await _details.Update(toUpdate.Detail);
        if (!detailUpdate)
        {
          return Result<Crud>.Fail(new Error("UpdateCrudHandler", $"{nameof(_entities)} Failed to update Detail ID# {request.Id}.  There may be remnants of an Entity without Detail saved."));
        }

        return Result<Crud>.Ok(toUpdate);
      }
      catch (Exception ex)
      {
        return Result<Crud>.Fail(ex);
      }




    }




  }
}
