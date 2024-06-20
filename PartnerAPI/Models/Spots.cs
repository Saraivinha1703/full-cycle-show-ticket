namespace PartnerAPI.Models;

public enum SpotStatus {
    Taken,
    Available
}

public class Spots {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public SpotStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required Guid EventId { get; set; }
}