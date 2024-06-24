
using Caticket.PartnerAPI.Domain.Interfaces.DTO.Event;

namespace Caticket.PartnerAPI.Web.DTO;

public record CreateEventDto(
    string Name,
    string? Description,
    DateTime Date,
    DateTime? UpdatedAt,
    DateTime? CreatedAt,
    decimal Price
) : ICreateEventDto;