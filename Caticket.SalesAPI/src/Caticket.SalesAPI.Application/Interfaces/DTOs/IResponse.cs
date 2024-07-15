namespace Caticket.SalesAPI.Application.Interfaces.DTOs;

public interface IResponse {
    bool Success { get; }
    
    List<string>? Errors { get; }
    
    void AddError(string error);

    void AddErrors(IEnumerable<string> errors);
}