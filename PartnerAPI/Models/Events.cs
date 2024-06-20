namespace PartnerAPI.Models;

public class Events {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public decimal Price { get; set; }
}