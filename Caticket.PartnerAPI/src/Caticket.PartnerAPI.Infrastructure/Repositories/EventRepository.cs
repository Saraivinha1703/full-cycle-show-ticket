using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;
using Caticket.PartnerAPI.Infrastructure.Interfaces;

namespace Caticket.PartnerAPI.Infrastructure.Repositories;

public class EventRepository(DatabaseContext dbContext) : Repository<Event>(dbContext), IEventRepository
{
    public async Task<IEnumerable<Event>> GetEventByNameAsync(string name) {
        Console.WriteLine("Name from Repo: " + name);
        return await GetAllAsync(e => e.Name == name);
    }
}