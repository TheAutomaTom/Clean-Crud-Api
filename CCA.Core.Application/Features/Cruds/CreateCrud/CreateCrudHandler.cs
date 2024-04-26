using FluentValidation.Results;
using Mediator;
using Microsoft.Extensions.Logging;
using CCA.Core.Application.Features.Cruds.CreateCrud;
using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;

namespace CCA.Core.Application.Features.Cruds.CreateCrud
{
  public class CreateCrudHandler : IRequestHandler<CreateCrudRequest, CreateCrudResponse>
  {
    readonly ICrudDetailRepository _details;
    readonly ICrudRepository _entities;
    readonly ILogger<CreateCrudHandler> _logger;

    public CreateCrudHandler(ILogger<CreateCrudHandler> logger, ICrudRepository entities, ICrudDetailRepository details)
    {
      _logger = logger;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<CreateCrudResponse> Handle(CreateCrudRequest request, CancellationToken ct)
    {
      var validator = new CreateCrudValidator();
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
      {
        var errors = new List<ValidationFailure>();
        foreach (var error in validationResult.Errors)
        {
          errors.Add(error);
        }
        return new CreateCrudResponse() { ValidationErrors = errors };
      }

      try
      {
        var entity = new Crud(request.Name, request.Department);
        var createdId = await _entities.Create(entity);
        if (createdId == 0)
        {
          throw new Exception("Failed to create Entity.");
        }

        var detail = new CrudDetail(createdId, request.Description, request.Tags);
        var createdDetailId = await _details.Create(detail);
        if (createdDetailId == 0)
        {
          throw new Exception("Failed to create Detail.");
        }

        var result = new Crud(createdId, entity, detail);
        return new CreateCrudResponse(new Crud(createdId, entity, detail));

      }
      catch (Exception ex)
      {
        var response = new CreateCrudResponse() { Exception = ex };
        return response;
      }
    }





  }
}
