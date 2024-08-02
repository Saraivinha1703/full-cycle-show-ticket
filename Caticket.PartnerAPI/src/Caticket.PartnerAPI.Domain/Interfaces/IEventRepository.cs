using Caticket.PartnerAPI.Domain.Entities;

namespace Caticket.PartnerAPI.Domain.Interfaces;

public interface IEventRepository : IRepository<Event> {
    IEnumerable<Event> GetEventByName(string name);
}