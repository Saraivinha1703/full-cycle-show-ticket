using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;

namespace Caticket.PartnerAPI.Core.Services;

public class SpotService(
    ISpotRepository spotRepository, 
    IEventRepository eventRepository,
    IUnitOfWork unitOfWork) {
    private readonly ISpotRepository _spotRepository = spotRepository;
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Spot>> GetAllSpots(Guid eventId) {
        return await _spotRepository.GetAllAsync(s => s.EventId == eventId);
    }

    public async Task<Spot> CreateSpot(Guid eventId, Spot createSpot) {
        var _ = await _eventRepository.GetByIdAsync(eventId) ?? throw new Exception("Invalid event Id");
        
        try {
            await _spotRepository.CreateAsync(createSpot);

            await _unitOfWork.Commit();
            return createSpot;
        } catch(Exception ex) {
            throw new Exception($"Something went wrong while creating the spot: {ex.Message}");
        }
    } 
}