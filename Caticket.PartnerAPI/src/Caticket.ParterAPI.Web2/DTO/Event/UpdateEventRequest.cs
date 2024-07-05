
namespace Caticket.PartnerAPI.Web2.DTO.Event;

public record UpdateEventRequest(
    Guid Id,
    string Name, 
    string? Description, 
    string Date, 
    decimal Price
);