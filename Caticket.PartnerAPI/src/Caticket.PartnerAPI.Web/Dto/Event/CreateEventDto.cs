
using Caticket.PartnerAPI.Domain.Interfaces.DTO.Event;

namespace Caticket.PartnerAPI.Web.DTO;

public record CreateEventDto(
    string Name,
    string? Description,
    string Date,
    string? CreatedAt,
    decimal Price
) : ICreateEventDto;