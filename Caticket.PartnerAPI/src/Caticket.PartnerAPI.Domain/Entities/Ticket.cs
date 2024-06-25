using Caticket.PartnerAPI.Domain.Enums;

namespace Caticket.PartnerAPI.Domain.Entities;

public class Ticket : BaseEntity {
    public required string Email { get; set; }
    public TicketKind TicketKind { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required virtual Spot Spot { get; set; }
}