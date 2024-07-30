using System.Formats.Asn1;
using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Enumerators;
using Caticket.SalesAPI.Domain.Interfaces;

namespace Caticket.SalesAPI.Core.Services;

public class EventService(IRepository<Event> eventRepository) {
    private readonly IRepository<Event> _eventRepository = eventRepository;
    
    public Task<Spot> AddSpot(string name) {
        return Task.FromResult(new Spot("", Guid.NewGuid(), SpotStatus.Available));
    }
 
    public async Task<List<Event>> ListEvents() 
        => (await _eventRepository.GetAllAsync()).ToList();


    public async Task<Event> GetEvent(Guid eventId) 
        => await _eventRepository.GetByIdAsync(eventId);
} 