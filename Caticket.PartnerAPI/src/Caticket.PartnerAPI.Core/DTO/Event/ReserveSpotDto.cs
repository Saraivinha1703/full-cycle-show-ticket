using Caticket.PartnerAPI.Domain.Enumerators;

namespace Caticket.PartnerAPI.Core.DTO.Event;

public record ReserveSpotDto(List<SpotDto> Spots, string Email, string TicketType);

public class SpotDto {
    public required string Name { get; set; }
    public required string Owner { get; set; }
    public required string OwnerLegalId { get; set; }
}