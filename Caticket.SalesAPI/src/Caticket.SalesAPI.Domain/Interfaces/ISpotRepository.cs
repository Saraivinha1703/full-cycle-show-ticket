using Caticket.SalesAPI.Domain.Entities;

namespace Caticket.SalesAPI.Domain.Interfaces;

public interface ISpotRepository : IRepository<Spot> {
    IQueryable<Spot> FindSpotsByEventId(Guid eventId);
    Task<Spot> FindSpotByName(Guid eventId, string name);
    //Task ReserveSpot(Guid spotId, Guid ticketId);
}