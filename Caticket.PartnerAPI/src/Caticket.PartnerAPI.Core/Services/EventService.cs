using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;

namespace Caticket.PartnerAPI.Core.Services;

public class EventService(IEventRepository eventRepository) {
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task CreateEvent(string name) {
        Event e = new() {Name = name};
        await _eventRepository.CreateAsync(e);
    }

    public async Task<IEnumerable<Event>> GetEventByName(string name) {
        return await _eventRepository.GetEventByNameAsync(name);
    }
}