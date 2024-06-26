
namespace Caticket.PartnerAPI.Web.DTO.Event;

public record UpdateEventRequest(
    Guid Id,
    string Name, 
    string? Description, 
    string Date, 
    decimal Price
);