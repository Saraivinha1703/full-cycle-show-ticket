namespace Caticket.PartnerAPI.Domain.Interfaces.DTO.Event;

public interface IUpdateEventDto {
    Guid Id {get;}
    string Name {get;} 
    string? Description {get;}
    DateTime Date {get;} 
    decimal Price {get;}
}