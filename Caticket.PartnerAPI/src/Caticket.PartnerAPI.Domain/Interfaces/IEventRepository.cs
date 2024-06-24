using Caticket.PartnerAPI.Domain.Entities;

namespace Caticket.PartnerAPI.Domain.Interfaces;

public interface IEventRepository : IRepository<Event> {
    Task<IEnumerable<Event>> GetEventByNameAsync(string name);
}