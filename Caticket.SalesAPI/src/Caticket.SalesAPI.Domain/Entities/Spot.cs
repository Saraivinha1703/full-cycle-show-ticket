using Caticket.SalesAPI.Domain.Types;

namespace Caticket.SalesAPI.Domain.Entities;

public class Spot(
    string name, 
    Guid eventId, 
    Guid TicketId, 
    SpotStatus? spotStatus = null
) : BaseEntity {
    public string Name {get; set;} = name;
    public SpotStatus SpotStatus { get; set; } = spotStatus ?? SpotStatus.Available;
    public Guid EventId {get; set;} = eventId;
    public Guid TicketId {get; set;} = TicketId;
}
