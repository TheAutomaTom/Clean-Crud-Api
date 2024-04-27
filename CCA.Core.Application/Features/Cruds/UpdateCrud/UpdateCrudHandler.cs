using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Responses;
using CCA.Core.Infra.Models.Results;
using FluentValidation.Results;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.UpdateCrud
{
  public class UpdateCrudHandler : IRequestHandler<UpdateCrudRequest, Result>
  {
    readonly ICrudDetailRepository _details;
    readonly ICrudRepository _entities;
    readonly ILogger<UpdateCrudHandler> _logger;

    public UpdateCrudHandler(ILogger<UpdateCrudHandler> logger, ICrudRepository entities, ICrudDetailRepository details)
    {
      _logger = logger;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<Result> Handle(UpdateCrudRequest request, CancellationToken cancellationToken)
    {

      // Validate request
      var validator = new UpdateCrudValidator();
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
      {
        return Result.Fail(validationResult.Errors);
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

        var errors = new List<Error>();

        var entityUpdate = await _entities.Update(toUpdate);
        if (!entityUpdate)
        {
          errors.Add(new Error("UpdateCrudHandler", $"{nameof(_entities)} Failed to update entity ID# {request.Id}."));
        }

        var detailUpdate = await _details.Update(toUpdate.Detail);
        if (!detailUpdate)
        {
          errors.Add(new Error("UpdateCrudHandler", $"{nameof(_details)} Failed to update detail ID# {request.Id}."));
        }

        if(errors.Any())
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
