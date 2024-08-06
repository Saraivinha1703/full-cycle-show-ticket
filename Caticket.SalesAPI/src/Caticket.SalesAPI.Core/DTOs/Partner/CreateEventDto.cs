namespace Caticket.SalesAPI.Core.DTOs.Partner;

public record CreateEventRequest(
    string Name,
    string Date,
    string Location,
    string Organization,
    string ImageURL,
    int Capacity,
    decimal Price,
    string? Description,
    string? Rating
);

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