using Caticket.PartnerAPI.Domain.Entities;

namespace Caticket.PartnerAPI.Domain.Interfaces;

public interface ISpotRepository : IRepository<Spot> {
    Task<List<Spot>> FindManySpotsByName(List<string> spots, Guid eventId);
}