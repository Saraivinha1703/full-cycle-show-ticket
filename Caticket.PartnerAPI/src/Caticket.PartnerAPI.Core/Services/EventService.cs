using Caticket.PartnerAPI.Core.DTO.Event;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enums;
using Caticket.PartnerAPI.Domain.Exceptions;
using Caticket.PartnerAPI.Domain.Interfaces;

namespace Caticket.PartnerAPI.Core.Services;

public class EventService(
    IEventRepository eventRepository, 
    ISpotRepository spotRepository, 
    IRepository<Ticket> ticketRepository,
    IRepository<ReservationHistory> reservationHistoryRepository,
    IUnitOfWork unitOfWork
    ) {
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly ISpotRepository _spotRepository = spotRepository;
    private readonly IRepository<Ticket> _ticketRepository = ticketRepository;
    private readonly IRepository<ReservationHistory> _reservationHistoryRepository = reservationHistoryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


    public async Task<Event> CreateEvent(Event e) {
        try {
            await _eventRepository.CreateAsync(e);
            await _unitOfWork.Commit();
            return e;
        } catch (Exception ex) {
            throw new Exception($"Something went wrong while creating the event: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Event>> GetEventByName(string name) {
        return await _eventRepository.GetEventByNameAsync(name);
    }

    public async Task<IEnumerable<Event>> GetAllEvents() {
        return await _eventRepository.GetAllAsync();
    }

    public async Task<Event> Update(Event updateEvent) {
        try {
            var ev = await _eventRepository.GetByIdAsync(updateEvent.Id, true);

            ev.Name = updateEvent.Name;
            ev.Description = updateEvent.Description;
            ev.Date = updateEvent.Date;
            ev.CreatedAt = updateEvent.CreatedAt;
            ev.UpdatedAt = updateEvent.UpdatedAt;
            ev.Price = updateEvent.Price;

            await _unitOfWork.Commit();

            return ev;
        }  catch(Exception) {
            throw new IdNotFoundException("Something went wrong while updating the event");
        }
    } 

    public async Task<Event> GetEventById(Guid eventId) {
        return await _eventRepository.GetByIdAsync(eventId);
    }

    public async Task<Tuple<List<string>, List<Ticket>?>> ReserveSpot(ReserveSpotDto reserveSpots, Guid eventId) {
        List<string> messages = [];
        var spots = await _spotRepository.FindManySpotsByName(reserveSpots.Spots, eventId, true);
        
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
            List<ReservationHistory> reservationHistories = [];
            
            spots.ForEach(s => s.Status = SpotStatus.Reserved);
            spots.ForEach(s => {
                tickets.Add(
                    new() { 
                        Email = reserveSpots.Email, 
                        CreatedAt = DateTime.Now, 
                        TicketKind = reserveSpots.TicketKind, 
                        SpotId = s.Id, 
                    }
                );

                reservationHistories.Add(
                    new() { 
                        Email = reserveSpots.Email, 
                        CreatedAt = DateTime.Now, 
                        TicketKind = reserveSpots.TicketKind, 
                        SpotId = s.Id, 
                    }
                );
            });

            try {
                await _ticketRepository.CreateRangeAsync(tickets);
                await _reservationHistoryRepository.CreateRangeAsync(reservationHistories);

                await _unitOfWork.Commit();
                messages.Add("Spots reserved.");

                return new(messages, tickets);
            } catch(Exception) {
                throw new IdNotFoundException("Something went wrong while reservation spots");
            }
        }
    }

    public async Task Delete(Guid id){
        try {
            await _eventRepository.DeleteAsync(id);	
            await _unitOfWork.Commit();
        } catch (Exception)
        {
            throw new IdNotFoundException("Something went wrong while deleting the event");
        }
    }
}