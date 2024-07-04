using Caticket.SalesAPI.Core.Exceptions.Spot;
using Caticket.SalesAPI.Domain.Entities;

namespace Caticket.SalesAPI.Core.Services;

public class SpotService {
    public Task<Spot> CreateSpot(Guid eventId, Spot spot) {
        ValidateSpot(spot);
        return Task.FromResult(spot);
    }

    private void ValidateSpot(Spot spot) {
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