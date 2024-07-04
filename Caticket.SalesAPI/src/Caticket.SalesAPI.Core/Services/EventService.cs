using Caticket.SalesAPI.Domain.Entities;

namespace Caticket.SalesAPI.Core.Services;

public class EventService {
    public Task<Spot> AddSpot(string name) {
        return Task.FromResult(new Spot("", Guid.NewGuid(), Guid.NewGuid()));
    }
}