namespace Caticket.PartnerAPI.Web.Dto;

public record CreateEventDto(
    string Name, 
    string? Description, 
    DateTime? UpdatedAt, 
    DateTime? CreatedAt, 
    decimal Price
);