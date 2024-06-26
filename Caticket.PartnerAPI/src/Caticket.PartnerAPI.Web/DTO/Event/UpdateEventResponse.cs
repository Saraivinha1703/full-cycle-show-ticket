
namespace Caticket.PartnerAPI.Web.DTO.Event;

public record UpdateEventResponse(
    Guid Id,
    string Name, 
    string? Description, 
    string Date, 
    decimal Price
);