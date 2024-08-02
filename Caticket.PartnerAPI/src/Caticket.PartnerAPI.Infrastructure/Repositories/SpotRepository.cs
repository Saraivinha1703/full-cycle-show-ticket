using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;
using Caticket.PartnerAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Caticket.PartnerAPI.Infrastructure.Repositories;

public class SpotRepository(DatabaseContext dbContext, TenantProvider tenantProvider) : Repository<Spot>(dbContext, tenantProvider), ISpotRepository
{
    private readonly DatabaseContext _dbContext = dbContext;
    public async Task<List<Spot>> FindManySpotsByName(List<string> spotsToFind, Guid eventId, bool trackable = false)
    {
        if(TenantId == null) throw new ApplicationException("`FindManySpotsByName` on SpotRepository can not be executed without a tenant Id");

        var spots = trackable 
            ? await _dbContext.Set<Spot>()
                .Where(s => s.TenantId == TenantId && s.EventId == eventId)
                .Where(s => spotsToFind.Contains(s.Name))
                .AsTracking()
                .ToListAsync() 
            : await _dbContext.Set<Spot>()
                .Where(s => s.TenantId == TenantId && s.EventId == eventId)
                .Where(s => spotsToFind.Contains(s.Name))
                .AsNoTracking()
                .ToListAsync();
    
            spots.ForEach(spot => {
                Console.WriteLine("selected: " + spot.Id + " name: " + spot.Name);
            });
        return spots;
    }
}