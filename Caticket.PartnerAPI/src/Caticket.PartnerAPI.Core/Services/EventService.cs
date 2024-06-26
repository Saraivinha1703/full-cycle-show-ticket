using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;

namespace Caticket.PartnerAPI.Core.Services;

public class EventService(IEventRepository eventRepository) {
    private readonly IEventRepository _eventRepository = eventRepository;

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

        await _eventRepository.UpdateAsync(
            updateEvent
            // new() { 
            //     Id = e.Id,
            //     Name = updateEvent.Name,
            //     Description = updateEvent.Description,
            //     CreatedAt = updateEvent.CreatedAt,
            //     UpdatedAt = DateTime.Now,
            //     Price = updateEvent.Price,
            //     Date = updateEvent.Date,
            // }
        );
        return updateEvent;
    } 

    public async Task<Event> GetEventById(Guid eventId) {
        return await _eventRepository.GetByIdAsync(eventId);
    }

    public async Task Delete(Guid id){
        await _eventRepository.DeleteAsync(id);	
    }
}