using Caticket.PartnerAPI.Core.Entities;
using Caticket.PartnerAPI.Core.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;

namespace Caticket.PartnerAPI.Infrastructure.Repositories;

public class EventRepository(DatabaseContext<Event> context) : IRepository<Event>
{
    private readonly DatabaseContext<Event> context = context;

    public Task CreateAsync(Event e)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Event>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Event> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, Event entity)
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