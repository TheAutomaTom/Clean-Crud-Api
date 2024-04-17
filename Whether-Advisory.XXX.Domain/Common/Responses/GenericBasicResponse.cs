﻿using FluentValidation.Results;

namespace Whether_Advisory.XXX.Domain.Common.Responses
{
  public class BasicResponse<T> : BasicResponse
  {
    public T? Data { get; set; }
    public string DataType { get; set; } = typeof(T).Name;

    public BasicResponse(T payload) : base()
    {
      IsOk = true;
      Data = payload;
    }

    public BasicResponse(IEnumerable<ValidationFailure> validationErrors) : base(validationErrors)
    {
    }

    public BasicResponse()
    {
      Data = default;
    }

    public BasicResponse(Exception ex) : base(ex) { }

  }
}