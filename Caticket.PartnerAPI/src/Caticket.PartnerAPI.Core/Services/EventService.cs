using Caticket.PartnerAPI.Core.Interfaces.DTO;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;

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
}