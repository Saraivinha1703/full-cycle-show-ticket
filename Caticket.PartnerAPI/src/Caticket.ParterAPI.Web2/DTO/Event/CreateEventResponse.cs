
namespace Caticket.PartnerAPI.Web2.DTO.Event;

public record CreateEventResponse(
    Guid Id,
    string Name,
    string? Description,
    string Date,
    string? CreatedAt,
    decimal Price
);