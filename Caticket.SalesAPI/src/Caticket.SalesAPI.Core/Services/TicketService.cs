using Caticket.SalesAPI.Core.Exceptions.Ticket;
using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.Services;

public class TicketService {
    public TicketType TestTicketType(string name) {
        TicketType ticketType = Enumeration.From<TicketType>(name);
        
        return ticketType;
    }

    private static void ValidateTicket(Ticket ticket) {
        string message = "Error during validation";

        if(ticket.Price <= 0) {
            throw new TicketPriceZeroException(message);
        }
    }
}