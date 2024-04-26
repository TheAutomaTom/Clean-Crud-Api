using FluentValidation.Results;

namespace CCA.Core.Application.Features.Cruds.ReadCruds
{
  public class ReadCrudsValidator // : AbstractValidator<ReadCrudsRequest> // Fluent cannot validate nullable DateTimes
  {

    public ValidationResult Validate(ReadCrudsRequest request)
    {

      var result = new ValidationResult();
      if (request.Paging != null)
      {
        if (request.Paging.Page < 0)
        {
          result.Errors.Add(new ValidationFailure("Paging.Page", "Page must be greater than or equal to 0"));
        }

        if (request.Paging.CountPer < 0)
        {
          result.Errors.Add(new ValidationFailure("Paging.CountPer", "CountPer must be greater than or equal to 0"));

        }

      }

      if (request.UpdatedDateRange != null && request.UpdatedDateRange?.From != null)
      {
        if (request.UpdatedDateRange?.Until != null && request.UpdatedDateRange.Until < request.UpdatedDateRange.From)
        {
          result.Errors.Add(new ValidationFailure("UpdatedDateRange.Until", $"Until may not be earlier than UpdatedDateRange.From ({request.UpdatedDateRange.From})"));
        }
      }

      return result;


    }



  }
}
