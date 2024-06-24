using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enums;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Domain.Interfaces.DTO.Spot;

namespace Caticket.PartnerAPI.Core.Services;

public class SpotService(IRepository<Spot> spotRepository, IEventRepository eventRepository) {
    private readonly IRepository<Spot> _spotRepository = spotRepository;
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<IEnumerable<Spot>> GetAllSpots(Guid eventId) {
        return await _spotRepository.GetAllAsync(s => s.EventId == eventId);
    }

    public async Task<Spot> CreateSpot(Guid eventId, ICreateSpotDto createSpotDto) {
        var e = await _eventRepository.GetByIdAsync(eventId) ?? throw new Exception("Invalid event Id");
        
        Spot spot = new() {
            Name = createSpotDto.Name,
            CreatedAt = DateTime.Now,
            Status = SpotStatus.Available,
            EventId = eventId, 
        };

        await _spotRepository.CreateAsync(spot);

        return spot;
    } 
}