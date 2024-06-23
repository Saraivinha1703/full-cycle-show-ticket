
using System.Linq.Expressions;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Caticket.PartnerAPI.Infrastructure.Interfaces;

public abstract class Repository<T>(DatabaseContext dbContext) : IRepository<T> where T : class, IBaseEntity
{
    private readonly DatabaseContext _dbContext = dbContext;

    public virtual async Task CreateAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await SaveAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        T entity = await GetByIdAsync(id);

        _dbContext.Set<T>().Remove(entity);
        await SaveAsync();
    }

    public virtual Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, bool? queryable = false, bool? trackable = false)
    {
        IEnumerable<T> list = [];
        if(queryable == true && trackable == false) {
            if(predicate != null) {
                list = [.. _dbContext.Set<T>().Where(predicate).AsNoTracking().AsQueryable()];
            } else {
                list = [.. _dbContext.Set<T>().AsNoTracking().AsQueryable()];
            }
        } 
        else if(trackable == true && queryable == false) {
            if(predicate != null) {
                list = [.. _dbContext.Set<T>().Where(predicate).AsTracking()];
            } else {
                list = _dbContext.Set<T>().AsEnumerable().ToList();
            }
        } 
        else if (trackable == true && queryable == true) {
            if(predicate != null) {
                list = [.. _dbContext.Set<T>().Where(predicate).AsTracking().AsQueryable()];
            } else {
                list = [.. _dbContext.Set<T>().AsTracking().AsQueryable()];
            }
        }

        return Task.FromResult(list);
    }

    public virtual async Task<T> GetByIdAsync(Guid id) =>
        await _dbContext.Set<T>()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync() 
            ?? throw new Exception("The entity for this id");

    public virtual async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();

    public virtual async Task UpdateAsync(T entity)
    {
        _dbContext.Update(entity);
        await SaveAsync();
    }

    
    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        disposed = true;
    }

    public virtual void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}