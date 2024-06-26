namespace Caticket.PartnerAPI.Domain.Entities;

public class Event : BaseEntity {
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public decimal Price { get; set; }
}