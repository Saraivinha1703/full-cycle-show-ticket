using Caticket.PartnerAPI.Domain.Enums;

namespace Caticket.PartnerAPI.Domain.Entities;
public class ReservationHistory : BaseEntity {
    public string? Email { get; set; }
    public TicketKind TicketKind { get; set; }
    public SpotStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required Guid SpotId { get; set; }
}