using System.Formats.Asn1;
using Caticket.PartnerAPI.Core.DTO.Event;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enums;
using Caticket.PartnerAPI.Domain.Interfaces;

namespace Caticket.PartnerAPI.Core.Services;

public class EventService(IEventRepository eventRepository, ISpotRepository spotRepository, IRepository<Ticket> ticketRepository) {
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly ISpotRepository _spotRepository = spotRepository;
    private readonly IRepository<Ticket> _ticketRepository = ticketRepository;

    public async Task<Event> CreateEvent(Event e) {
        await _eventRepository.CreateAsync(e);
        return e;
    }

    public async Task<IEnumerable<Event>> GetEventByName(string name) {
        return await _eventRepository.GetEventByNameAsync(name);
    }

    public async Task<IEnumerable<Event>> GetAllEvents() {
        return await _eventRepository.GetAllAsync();
    }

    public async Task<Event> Update(Event updateEvent) {
        var _ = await _eventRepository.GetByIdAsync(updateEvent.Id) ?? throw new Exception("This event does not exist");

        await _eventRepository.UpdateAsync(updateEvent);
        return updateEvent;
    } 

    public async Task<Event> GetEventById(Guid eventId) {
        return await _eventRepository.GetByIdAsync(eventId);
    }

    public async Task<Tuple<List<string>, List<Ticket>?>> ReserveSpot(ReserveSpotDto reserveSpots, Guid eventId) {
        List<string> messages = [];
        var spots = await _spotRepository.FindManySpotsByName(reserveSpots.Spots, eventId);
        
        if(spots.Count == 0 || spots == null) {
            messages.Add("No spots found.");
            
            return new(messages, null);
        }

        if(spots.Count != reserveSpots.Spots.Count) {
            messages.Add("Not all spots were found.");
            
            return new(messages, null);
        }

        var reservedSpots = spots.FindAll(s => s.Status == SpotStatus.Reserved); 
        var availableSpots = spots.FindAll(s => s.Status == SpotStatus.Available);

        if (reservedSpots.Count > 0 && availableSpots.Count > 0) {
            reservedSpots.ForEach(s => messages.Add($"The spot '{s.Name}' is reserved."));
            availableSpots.ForEach(s => messages.Add($"The spot '{s.Name}' is available."));
            
            messages.Add("Select other available spots.");

            return new(messages, null);
        } else if (reservedSpots.Count > 0) {
            reservedSpots.ForEach(s => messages.Add($"The spot '{s.Name}' is reserved."));

            return new(messages, null);
        } else {
            List<Ticket> tickets = [];
            
            spots.ForEach(s => s.Status = SpotStatus.Reserved);
            spots.ForEach(s => tickets.Add(
                new() { 
                    Email = reserveSpots.Email, 
                    CreatedAt = DateTime.Now, 
                    TicketKind = reserveSpots.TicketKind, 
                    SpotId = s.Id, 
                }
            ));


            spots.ForEach(spot => {
                Console.WriteLine("updating selected: " + spot.Id + "\n name: " + spot.Name + "\n status: " + spot.Status);
            });

            await _ticketRepository.CreateRangeAsync(tickets);
            await _spotRepository.UpdateRangeAsync(spots);
            
            messages.Add("Spots reserved.");

            return new(messages, tickets);
        }
    }

    public async Task Delete(Guid id){
        await _eventRepository.DeleteAsync(id);	
    }
}