using Caticket.SalesAPI.Identity.Interfaces.DTOs;

namespace Caticket.SalesAPI.Identity.DTOs.Response;

public abstract class BaseResponse : IResponse
{
    public bool Success { get; protected set; }

    public List<string> Errors { get; protected set; } = [];

    public void AddError(string error) => Errors.Add(error);

    public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);
}