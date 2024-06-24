using Caticket.PartnerAPI.Domain.Enums;

namespace Caticket.PartnerAPI.Domain.Entities;

public class Spot : BaseEntity {
    public required string Name { get; set; }
    public SpotStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public required Guid EventId { get; set; }
}