using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Domain.Interfaces.DTO.Event;

namespace Caticket.PartnerAPI.Core.Services;

public class EventService(IEventRepository eventRepository) {
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<Event> CreateEvent(ICreateEventDto createEventDto) {
        Event e = new() {
            Name = createEventDto.Name, 
            Description = createEventDto.Description,
            Price = createEventDto.Price,
            Date = DateTime.Parse(createEventDto.Date),
            CreatedAt = createEventDto.CreatedAt != null 
                ? DateTime.Parse(createEventDto.CreatedAt) 
                : DateTime.Now,
        };
        await _eventRepository.CreateAsync(e);
        return e;
    }

    public async Task<IEnumerable<Event>> GetEventByName(string name) {
        return await _eventRepository.GetEventByNameAsync(name);
    }

    public async Task<IEnumerable<Event>> GetAllEvents() {
        return await _eventRepository.GetAllAsync();
    }

    public async Task Update(IUpdateEventDto updateEventDto) {
        var e = await _eventRepository.GetByIdAsync(updateEventDto.Id);

        await _eventRepository.UpdateAsync(
            new() { 
                Id = updateEventDto.Id,
                Name = updateEventDto.Name,
                Description = updateEventDto.Description,
                CreatedAt = e.CreatedAt,
                UpdatedAt = DateTime.Now,
                Price = updateEventDto.Price,
                Date = DateTime.Parse(updateEventDto.Date),
            }
        );
    } 

    public async Task Delete(Guid id){
        await _eventRepository.DeleteAsync(id);	
    }
}