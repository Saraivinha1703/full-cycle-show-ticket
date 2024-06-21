using Caticket.PartnerAPI.Core.Enums;

namespace Caticket.PartnerAPI.Core.Entities;
public class ReservationHistory : BaseId {
    public string? Email { get; set; }
    public TicketKind TicketKind { get; set; }
    public SpotStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required Guid SpotId { get; set; }
}