namespace Caticket.PartnerAPI.Core.Interfaces.DTO;

public interface ICreateEventDto {
    string Name {get;} 
    string? Description {get;}
    DateTime? UpdatedAt {get;} 
    DateTime? CreatedAt {get;} 
    decimal Price {get;}
}