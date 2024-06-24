
using Caticket.PartnerAPI.Domain.Interfaces.DTO.Event;

namespace Caticket.PartnerAPI.Web.DTO;

public record UpdateEventDto(
    Guid Id,
    string Name, 
    string? Description, 
    string Date, 
    decimal Price
) : IUpdateEventDto;