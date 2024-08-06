using Caticket.PartnerAPI.Domain.Enumerators;

namespace Caticket.PartnerAPI.Domain.Entities;

public class Event(
    string name,
    string location,
    string organization,
    string imageURL,
    int capacity,
    decimal price,
    DateTime date,
    DateTime createdAt,
    string? description = null,
    Rating? rating = null,
    DateTime? updatedAt = null
) : BaseEntity {
    public string Name { get; set; } = name;
    public string Location { get; set; } = location;
    public string Organization { get; set; } = organization;
    public string? Description { get; set; } = description;
    public Rating Rating { get; set; } = rating ?? Rating.G;
    public DateTime Date { get; set; } = date;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime? UpdatedAt { get; set; } = updatedAt;
    public string ImageURL { get; set; } = imageURL;
    public int Capacity { get; set; } = capacity;
    public decimal Price { get; set; } = price;
}