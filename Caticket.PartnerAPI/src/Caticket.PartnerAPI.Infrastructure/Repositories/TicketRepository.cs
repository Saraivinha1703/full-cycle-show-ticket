using Caticket.PartnerAPI.Core.Entities;
using Caticket.PartnerAPI.Core.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;

namespace Caticket.PartnerAPI.Infrastructure.Repositories;

public class TicketRepository(DatabaseContext<Ticket> context) : IRepository<Ticket>
{
    private readonly DatabaseContext<Ticket> context = context;

    public Task CreateAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Ticket>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Ticket> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, Ticket entity)
    {
        throw new NotImplementedException();
    }

    //IDisbosable interface implementation
    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}