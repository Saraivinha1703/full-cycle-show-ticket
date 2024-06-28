using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;

namespace Caticket.PartnerAPI.Infrastructure.Interfaces;

public class UnitOfWork(DatabaseContext dbContext) : IUnitOfWork
{
    private readonly DatabaseContext _dbContext = dbContext;

    public async Task<bool> Commit() => (await _dbContext.SaveChangesAsync()) > 0;

    public Task Rollback()
    {
        //Implement any rollback logic if needed
        return Task.CompletedTask;
    }
}