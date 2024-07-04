using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.Services;

public class TicketService {
    public TicketType TestTicketType(string name) {
        TicketType ticketType = Enumeration.From<TicketType>(name);
        
        return ticketType;
    }
}