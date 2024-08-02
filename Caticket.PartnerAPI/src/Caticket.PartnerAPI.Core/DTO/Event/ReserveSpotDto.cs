using Caticket.PartnerAPI.Domain.Enums;

namespace Caticket.PartnerAPI.Core.DTO.Event;

public record ReserveSpotDto(List<SpotDto> Spots, string Email, TicketKind TicketKind);
public class SpotDto {
    public required string Name { get; set; }
    public required string Owner { get; set; }
}