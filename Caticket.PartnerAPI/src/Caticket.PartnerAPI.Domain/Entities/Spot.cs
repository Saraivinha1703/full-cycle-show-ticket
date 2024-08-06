
using Caticket.PartnerAPI.Domain.Enumerators;

namespace Caticket.PartnerAPI.Domain.Entities;

public class Spot(
    Guid eventId,
    string name,
    DateTime createdAt,
    SpotStatus spotStatus,
    DateTime? updatedAt = null
) : BaseEntity {
    public string Name { get; set; } = name;
    public SpotStatus SpotStatus { get; set; } = spotStatus;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime? UpdatedAt { get; set; } = updatedAt;
    public Guid EventId { get; set; } = eventId;
    public virtual Event? Event { get; set; }
}