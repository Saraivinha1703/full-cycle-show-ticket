using Caticket.PartnerAPI.Core.Enums;

namespace Caticket.PartnerAPI.Core.Entities;

public class Spot : BaseId {
    public required string Name { get; set; }
    public SpotStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public required Guid EventId { get; set; }
}