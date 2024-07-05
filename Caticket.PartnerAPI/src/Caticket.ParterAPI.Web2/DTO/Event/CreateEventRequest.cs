
namespace Caticket.PartnerAPI.Web2.DTO.Event;

public record CreateEventRequest(
    string Name,
    string? Description,
    string Date,
    string? CreatedAt,
    decimal Price
);