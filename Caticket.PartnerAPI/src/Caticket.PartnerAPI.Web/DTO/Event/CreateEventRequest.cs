
namespace Caticket.PartnerAPI.Web.DTO.Event;

public record CreateEventRequest(
    string Name,
    string? Description,
    string Date,
    string? CreatedAt,
    decimal Price
);