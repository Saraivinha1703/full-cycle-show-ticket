namespace Caticket.PartnerAPI.Web.DTO.Event;

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