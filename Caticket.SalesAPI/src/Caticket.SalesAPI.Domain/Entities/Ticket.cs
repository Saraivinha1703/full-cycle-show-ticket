
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Domain.Entities;

public class Ticket(
    TicketType ticketType, 
    string owner,
    string ownerLegalIdentification,
    decimal price, 
    Guid eventId, 
    Spot spot
) : BaseEntity {
    public TicketType TicketType { get; set; } = ticketType;
    public string Owner { get; set; } = owner;
    public string OwnerLegalIdentification { get; set; } = ownerLegalIdentification;
    public decimal Price { get; set; } = price;
    public Guid EventId { get; set; } = eventId;
    public virtual Spot Spot { get; set; } = spot;
}