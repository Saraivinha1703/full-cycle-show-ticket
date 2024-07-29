using Caticket.SalesAPI.Domain.Interfaces;
using Caticket.SalesAPI.Core.Exceptions.Spot;
using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.Services;

public class SpotService(ISpotRepository spotRepository, IUnitOfWork _unitOfWork) {
    private readonly ISpotRepository _spotRepository = spotRepository;
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    
    public Task<Spot> CreateSpot(Guid eventId, Spot spot) {
        ValidateSpot(spot);
        return Task.FromResult(spot);
    }

    public async Task<Spot> FindSpotByName(Guid eventId, string name) 
        => await _spotRepository.FindSpotByName(eventId, name);

    public async Task<IEnumerable<Spot>> CreateSpotsRange(Guid eventId, int quantity, int rowMax = 10) {
        if(quantity <= 0 || rowMax <= 0) throw new InvalidSpotQuantityException("Error during Spots creation service");

        List<Spot> existingSpots = (await _spotRepository.GetAllAsync()).ToList();
        int currLetter = existingSpots.Count > 0 ? 65 + existingSpots.Count : 65;

        List<Spot> spots = [];
        
        for(int i = 0; i < quantity; i++) {
            for(int j = 0; j < rowMax; j++) {
                spots.Add(new($"{(char)currLetter}{j}", eventId, SpotStatus.Available));
                quantity--;
            }
            currLetter++;
        }

        try {
            await _spotRepository.CreateRangeAsync(spots);
            await _unitOfWork.Commit();

            return spots;
        } catch {
            throw;
        }
    }

    public async Task ReserveSpot(Guid spotId, Guid ticketId) {
        Spot spot = await _spotRepository.GetByIdAsync(spotId, true);

        if(spot.Status == SpotStatus.Reserved) {
            throw new SpotAlreadyReservedException("Error during reserving Spot service");
        }

        try {
            spot.Status = SpotStatus.Reserved;
            spot.TicketId = ticketId;
        
            await _unitOfWork.Commit();
        } catch(Exception ex) {
            throw new Exception($"Error while trying to update Spot to be reserved: {ex.Message}", ex);
        }
    }

    private static void ValidateSpot(Spot spot) {
        string message = "Error during validation";

        if(string.IsNullOrWhiteSpace(spot.Name)) {
            throw new SpotNameRequiredException(message);
        }

        if(spot.Name.Length < 2) {
            throw new SpotNameRequiredException(message);
        }

        if(!char.IsLetter(spot.Name[0]) && !char.IsUpper(spot.Name[0])) {
            throw new SpotNameMustStartWithLetterException(message);
        }

        if(!char.IsDigit(spot.Name[^1])) {
            throw new SpotNameMustEndWithNumberException(message);
        }
    }
}