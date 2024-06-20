namespace PartnerAPI.Models;

public enum TicketKind {
    Full,
    Half
}

public class Ticket : BaseId {
    public required string Email { get; set; }
    public TicketKind TicketKind { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid SpotId { get; set; }
}