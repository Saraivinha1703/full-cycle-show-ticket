using Caticket.PartnerAPI.Core.Entities;
using Caticket.PartnerAPI.Core.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;

namespace Caticket.PartnerAPI.Infrastructure.Repositories;

public class ReservationHistoryRepository(DatabaseContext<ReservationHistory> context) : IRepository<ReservationHistory>
{
    private readonly DatabaseContext<ReservationHistory> context = context;

    public Task CreateAsync(ReservationHistory reservationHistory)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<ReservationHistory>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ReservationHistory> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, ReservationHistory entity)
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