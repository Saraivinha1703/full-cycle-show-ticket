using Caticket.SalesAPI.Application.Interfaces.DTOs;

namespace Caticket.SalesAPI.Application.DTOs.Response;

public abstract class BaseResponse : IResponse
{
    public bool Success { get; protected set; }

    public List<string>? Errors { get; protected set; }

    public void AddError(string error) => Errors?.Add(error);

    public void AddErrors(IEnumerable<string> errors) => Errors?.AddRange(Errors);
}