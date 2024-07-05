using Caticket.SalesAPI.Domain.Interfaces;
using Caticket.SalesAPI.Infrastructure.Data;

namespace Caticket.SalesAPI.Infrastructure.Interfaces;

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