using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Common.Responses;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;
using FluentValidation.Results;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.UpdateCrud
{
  public class UpdateCrudHandler : IRequestHandler<UpdateCrudRequest, BasicResponse>
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

    public async ValueTask<BasicResponse> Handle(UpdateCrudRequest request, CancellationToken cancellationToken)
    {

      // Validate request
      var validator = new UpdateCrudValidator();
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
      {
        var errors = new List<ValidationFailure>();
        foreach (var error in validationResult.Errors)
        {
          errors.Add(error);
        }
        return new BasicResponse() { ValidationErrors = errors };
      }


      // Attempt process
      try
      {
          var messages = new List<string>();

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
          messages.Append($"{nameof(_entities)} Failed to update entity ID# {request.Id}.");

        }

        var detailUpdate = await _details.Update(toUpdate.Detail);
        if (!detailUpdate)
        {
          messages.Append($"{nameof(_details)} Failed to update detail ID# {request.Id}.");
        }

        return new BasicResponse() { Messages = new string[] { $"Crud ID# {request.Id} deleted." } };
      }
      catch (Exception ex)
      {
        var response = new BasicResponse() { Exception = ex };
        return response;
      }




    }




  }
}
