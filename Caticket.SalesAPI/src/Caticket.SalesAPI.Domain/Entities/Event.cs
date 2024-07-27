using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Domain.Entities;

public class Event(
    string name, 
    string location, 
    string organization, 
    DateTime date, 
    string imageURL, 
    int capacity, 
    decimal price, 
    Guid partnerId, 
    Rating? rating = null
) : BaseEntity
{
    public string Name { get; set; } = name;
    public string Location { get; set; } = location;
    public string Organization { get; set; } = organization;
    public Rating Rating { get; set; } = rating ?? Rating.G;
    public DateTime Date { get; set; } = date;
    public string ImageURL { get; set; } = imageURL;
    public int Capacity { get; set; } = capacity;
    public decimal Price { get; set; } = price;
    public Guid PartnerId { get; set; } = partnerId;

    public ICollection<Spot>? Spots { get; set; }
    public ICollection<Ticket>? Tickets { get; set; }
}
