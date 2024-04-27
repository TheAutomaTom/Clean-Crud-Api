using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Common.Responses;
using FluentValidation.Results;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.DeleteCrudById
{
  public class DeleteCrudByIdHandler : IRequestHandler<DeleteCrudByIdRequest, BasicResponse>
  {
    readonly ICrudDetailRepository _details;
    readonly ICrudRepository _entities;
    readonly ILogger<DeleteCrudByIdHandler> _logger;

    public DeleteCrudByIdHandler(ILogger<DeleteCrudByIdHandler> logger, ICrudRepository entities, ICrudDetailRepository details)
    {
      _logger = logger;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<BasicResponse> Handle(DeleteCrudByIdRequest request, CancellationToken cancellationToken)
    {
      var validator = new DeleteCrudByIdValidator();
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

      try
      {
        var messages = new List<string>();

        var entityAttempt = await _entities.Delete(request.Id);
        if (entityAttempt == 0)
        {
          messages.Append($"{nameof(_entities)} Failed to delete entity ID# {request.Id}.");
        }

        var detailAttempt = await _details.Delete(request.Id);
        if (detailAttempt == 0)
        {
          messages.Append($"{nameof(_details)} Failed to delete detail ID# {request.Id}.");
        }

        if (messages.Any())
        {
          return new BasicResponse(new Exception(String.Join("  ", messages)));
        }

        return new BasicResponse() { Messages = new string[] { $"Crud ID# {request.Id} deleted." } };

      }
      catch (Exception ex)
      {
        var response = new CreateCrudResponse() { Exception = ex };
        return response;
      }
    }





  }
}

