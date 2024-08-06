
namespace Caticket.PartnerAPI.Web.DTO.Event;

public record UpdateEventRequest(
    Guid Id,
    string Name,
    string Location,
    string Organization,
    string ImageURL,
    int Capacity,
    decimal Price,
    string Date, 
    string? Rating,
    string? Description 
     
);