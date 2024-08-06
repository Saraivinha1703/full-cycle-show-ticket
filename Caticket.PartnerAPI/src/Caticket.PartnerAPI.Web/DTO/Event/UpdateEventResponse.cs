
namespace Caticket.PartnerAPI.Web.DTO.Event;

public record UpdateEventResponse(
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
    string? Rating,
    string? Description 
);