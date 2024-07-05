
namespace Caticket.PartnerAPI.Web2.DTO.Event;

public record UpdateEventResponse(
    Guid Id,
    string Name, 
    string? Description, 
    string Date, 
    decimal Price
);