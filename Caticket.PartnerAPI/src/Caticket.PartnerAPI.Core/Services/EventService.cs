using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Domain.Interfaces.DTO.Event;

namespace Caticket.PartnerAPI.Core.Services;

public class EventService(IEventRepository eventRepository) {
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task CreateEvent(ICreateEventDto createEventDto) {
        Event e = new() {Name = createEventDto.Name};
        await _eventRepository.CreateAsync(e);
    }

    public async Task<IEnumerable<Event>> GetEventByName(string name) {
        return await _eventRepository.GetEventByNameAsync(name);
    }

    public async Task<IEnumerable<Event>> GetAllEvents() {
        return await _eventRepository.GetAllAsync();
    }

    public async Task Update(IUpdateEventDto updateEventDto) {
        await _eventRepository.UpdateAsync(
            new() { 
                Id = updateEventDto.Id,
                Name = updateEventDto.Name,
                Description = updateEventDto.Description,
                UpdatedAt = DateTime.Now,
                Price = updateEventDto.Price,
                Date = updateEventDto.Date,
            }
        );
    } 

    public async Task Delete(Guid id){
        await _eventRepository.DeleteAsync(id);	
    }
}