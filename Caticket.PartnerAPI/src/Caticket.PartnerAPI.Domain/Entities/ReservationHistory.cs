using Caticket.PartnerAPI.Domain.Enumerators;

namespace Caticket.PartnerAPI.Domain.Entities;
public class ReservationHistory(
    Guid spotId,
    string email,
    string owner,
    string ownerLegalId,
    string spotName,
    TicketType ticketType,
    DateTime createdAt,
    DateTime? updatedAt = null
) : BaseEntity {
    public string Email { get; set; } = email;
    public string Owner { get; set; } = owner;
    public string OwnerLegalId { get; set; } = ownerLegalId;
    public string SpotName { get; set; } = spotName;
    public TicketType TicketType { get; set; } = ticketType;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime? UpdatedAt { get; set; } = updatedAt;
    public Guid SpotId { get; set; } = spotId;
    public virtual Spot? Spot {get; set;}
}