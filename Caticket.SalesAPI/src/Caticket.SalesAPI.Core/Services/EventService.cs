using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.Services;

public class EventService {
    public Task<Spot> AddSpot(string name) {
        return Task.FromResult(new Spot("", Guid.NewGuid(), SpotStatus.Available));
    }
}