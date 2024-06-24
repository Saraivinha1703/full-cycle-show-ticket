using Caticket.PartnerAPI.Core.Interfaces.DTO;

namespace Caticket.PartnerAPI.Web.DTO;

public record CreateEventDto(
    string Name, 
    string? Description, 
    DateTime? UpdatedAt, 
    DateTime? CreatedAt, 
    decimal Price
) : ICreateEventDto;