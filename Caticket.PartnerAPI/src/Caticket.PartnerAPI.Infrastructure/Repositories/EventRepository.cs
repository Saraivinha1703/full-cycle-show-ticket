using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;
using Caticket.PartnerAPI.Infrastructure.Interfaces;

namespace Caticket.PartnerAPI.Infrastructure.Repositories;

public class EventRepository(DatabaseContext dbContext, TenantProvider tenantProvider) : Repository<Event>(dbContext, tenantProvider), IEventRepository
{
    public async Task<IEnumerable<Event>> GetEventByNameAsync(string name) {
        return await GetAllAsync(e => e.Name == name);
    }
}