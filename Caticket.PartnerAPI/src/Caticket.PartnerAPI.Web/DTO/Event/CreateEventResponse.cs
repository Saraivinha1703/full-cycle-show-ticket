
namespace Caticket.PartnerAPI.Web.DTO.Event;

public record CreateEventResponse(
    Guid Id,
    string Name,
    string Location,
    string Organization,
    string ImageURL,
    int Capacity,
    decimal Price,
    string Date,
    string CreatedAt,
    Guid TenantId,
    string? Description,
    string? Rating
);