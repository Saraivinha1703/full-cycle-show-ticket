
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Domain.Entities;

public class Ticket(
    TicketType ticketType, 
    decimal price, 
    Guid eventId, 
    Spot? spot = null
) : BaseEntity {
    public TicketType TicketType { get; set; } = ticketType;
    public decimal Price { get; set; } = price;
    public Guid EventId { get; set; } = eventId;
    public virtual Spot? Spot { get; set; } = spot;
}