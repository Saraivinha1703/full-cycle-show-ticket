namespace Caticket.PartnerAPI.Domain.Interfaces.DTO.Event;

public interface ICreateEventDto {
    string Name {get;} 
    string? Description {get;}
    DateTime Date {get;} 
    DateTime? UpdatedAt {get;} 
    DateTime? CreatedAt {get;} 
    decimal Price {get;}
}