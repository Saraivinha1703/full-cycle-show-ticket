
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Domain.Entities;

public class Spot(
    string name, 
    Guid eventId, 
    SpotStatus spotStatus,
    Guid? TicketId = null 
) : BaseEntity {
    public string Name {get; set;} = name;
    public SpotStatus Status { get; set; } = spotStatus;
    public Guid EventId {get; set;} = eventId;
    public Guid? TicketId {get; set;} = TicketId;
}
