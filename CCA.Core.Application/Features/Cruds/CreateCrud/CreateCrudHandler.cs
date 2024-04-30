using CCA.Core.Application.Interfaces.Persistence;
using CCA.Core.Application.Interfaces.Persistence.Cruds;
using CCA.Core.Domain.Models.Cruds;
using CCA.Core.Domain.Models.Cruds.Repo;
using CCA.Core.Infra.Models.Responses;
using CCA.Core.Infra.Models.Results;
using FluentValidation.Results;
using Mediator;
using Microsoft.Extensions.Logging;

namespace CCA.Core.Application.Features.Cruds.CreateCrud
{
  public class CreateCrudHandler : IRequestHandler<CreateCrudRequest, Result<Crud>>
  {
    readonly ICrudDetailsRepository _details;
    readonly ICrudEntitiesRepository _entities;
    readonly ILogger<CreateCrudHandler> _logger;

    public CreateCrudHandler(ILogger<CreateCrudHandler> logger, ICrudEntitiesRepository entities, ICrudDetailsRepository details)
    {
      _logger = logger;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<Result<Crud>> Handle(CreateCrudRequest request, CancellationToken ct)
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
        return Result<Crud>.Fail(validationResult.Errors);
      }

      try
      {
        var entity = new Crud(request.Name, request.Department);
        var createdId = await _entities.Create(entity);
        if (createdId == 0)
        {
          var e = new Error("CreateCrudHandler", "Failed to create Entity.");
          return Result<Crud>.Fail(e);
        }

        var detail = new CrudDetail(createdId, request.Description, request.Tags);
        var createdDetailId = await _details.Create(detail);
        if (createdDetailId == 0)
        {
          var e = new Error("CreateCrudHandler", "Failed to create Detail.  There may be remnants of a Entity with no related Detail.");
          return Result<Crud>.Fail(e);
        }

        var result = new Crud(createdId, entity, detail);
        return Result<Crud>.Ok(result);

      }
      catch (Exception ex)
      {
        return Result<Crud>.Fail(ex);
      }
    }





  }
}
