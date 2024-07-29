using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Exceptions;
using Caticket.SalesAPI.Domain.Interfaces;
using Caticket.SalesAPI.Infrastructure.Data;
using Caticket.SalesAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Caticket.SalesAPI.Infrastructure.Repositories;

public class SpotRepository(DatabaseContext dbContext) : Repository<Spot>(dbContext), ISpotRepository
{
    private readonly DatabaseContext _dbContext = dbContext;
    public async Task<Spot> FindSpotByName(Guid eventId, string name)
        => await _dbContext.Set<Spot>()
            .Where(s => s.EventId == eventId)
            .FirstOrDefaultAsync(s => s.Name == name) 
            ?? throw new EntityNotFoundException("Spot");

    public IQueryable<Spot> FindSpotsByEventId(Guid eventId)
        => _dbContext.Set<Spot>().Where(s => s.EventId == eventId);

    // public Task ReserveSpot(Guid spotId, Guid ticketId)
    // {
    //     throw new NotImplementedException();
    // }
}