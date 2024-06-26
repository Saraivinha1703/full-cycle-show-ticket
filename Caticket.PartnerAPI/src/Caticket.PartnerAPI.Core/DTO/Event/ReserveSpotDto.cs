using Caticket.PartnerAPI.Domain.Enums;

namespace Caticket.PartnerAPI.Core.DTO.Event;

public record ReserveSpotDto(List<string> Spots, string Email, TicketKind TicketKind);