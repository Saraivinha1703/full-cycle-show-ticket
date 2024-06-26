using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;
using Caticket.PartnerAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Caticket.PartnerAPI.Infrastructure.Repositories;

public class SpotRepository(DatabaseContext dbContext) : Repository<Spot>(dbContext), ISpotRepository
{
    private readonly DatabaseContext _dbContext = dbContext;
    public async Task<List<Spot>> FindManySpotsByName(List<string> spotsToFind, Guid eventId)
    {
        var spots = await _dbContext.Set<Spot>()
            .Where(s => s.EventId == eventId)
            .Where(s => spotsToFind.Contains(s.Name))
            .AsNoTracking()
            .ToListAsync();
    
            spots.ForEach(spot => {
                Console.WriteLine("selected: " + spot.Id + " name: " + spot.Name);
            });
        return spots;
    }
}