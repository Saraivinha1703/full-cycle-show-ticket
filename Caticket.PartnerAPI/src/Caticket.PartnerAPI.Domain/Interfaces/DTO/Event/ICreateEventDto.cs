namespace Caticket.PartnerAPI.Domain.Interfaces.DTO.Event;

public interface ICreateEventDto {
    string Name {get;} 
    string? Description {get;}
    string Date {get;} 
    string? CreatedAt {get;} 
    decimal Price {get;}
}