using Caticket.SalesAPI.Core.Exceptions.Ticket;
using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Enumerators;
using Caticket.SalesAPI.Domain.Interfaces;

namespace Caticket.SalesAPI.Core.Services;

public class TicketService(IRepository<Event> eventRepository, IRepository<Ticket> ticketRepository) {
    private readonly IRepository<Event> _eventRepository = eventRepository;
    private readonly IRepository<Ticket> _ticketRepository = ticketRepository;
    
    public TicketType TestTicketType(string name) {
        TicketType ticketType = Enumeration.From<TicketType>(name);
        
        return ticketType;
    }

    public async Task CreateTickets(List<Ticket> tickets) 
        => await _ticketRepository.CreateRangeAsync(tickets);

    public async Task<decimal> CalculatePrice(Guid eventId, TicketType ticketType) {
        var ev = await _eventRepository.GetByIdAsync(eventId);

        if(TicketType.Half.Name == ticketType.Name) {
            return ev.Price / 2;
        } else {
            return ev.Price;
        }
    }

    private static void ValidateTicket(Ticket ticket) {
        string message = "Error during validation";

        if(ticket.Price <= 0) {
            throw new TicketPriceZeroException(message);
        }
    }
}