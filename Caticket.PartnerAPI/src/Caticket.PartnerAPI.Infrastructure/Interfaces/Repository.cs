
using System.Linq.Expressions;
using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Domain.Interfaces;
using Caticket.PartnerAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Caticket.PartnerAPI.Infrastructure.Interfaces;

public abstract class Repository<T>(DatabaseContext dbContext, TenantProvider tenantProvider) : IRepository<T> where T : class, IBaseEntity
{
    private readonly DatabaseContext _dbContext = dbContext;
    protected readonly Guid? TenantId = tenantProvider.GetTenantId();

    public virtual async Task CreateAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
    }
    
    public virtual async Task CreateRangeAsync(List<T> entities)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        T entity = await GetByIdAsync(id);

        _dbContext.Set<T>().Remove(entity);
    }

    public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, bool queryable = false, bool trackable = false, bool withTenant = false)
    {
        if(withTenant && TenantId == null) throw new ApplicationException("GetAll with tenant, does not work without TenantId");
         
        IEnumerable<T> list;
        if (queryable == true && trackable == false)
        {
            if (predicate != null)
            {
                list = [.. _dbContext.Set<T>().Where(t => !withTenant || t.TenantId == TenantId).Where(predicate).AsNoTracking().AsQueryable()];
            }
            else
            {
                list = [.. _dbContext.Set<T>().Where(t => !withTenant || t.TenantId == TenantId).AsNoTracking().AsQueryable()];
            }
        }
        else if (trackable == true && queryable == false)
        {
            if (predicate != null)
            {
                list = [.. _dbContext.Set<T>().Where(t => !withTenant || t.TenantId == TenantId).Where(predicate).AsTracking()];
            }
            else
            {
                list = [.. _dbContext.Set<T>().Where(t => !withTenant || t.TenantId == TenantId).AsTracking()];
            }
        }
        else if (trackable == true && queryable == true)
        {
            if (predicate != null)
            {
                list = [.. _dbContext.Set<T>().Where(t => !withTenant || t.TenantId == TenantId).Where(predicate).AsTracking().AsQueryable()];
            }
            else
            {
                list = [.. _dbContext.Set<T>().Where(t => !withTenant || t.TenantId == TenantId).AsTracking().AsQueryable()];
            }
        }
        else
        {
            if (predicate != null)
            {
                list = _dbContext.Set<T>().Where(t => !withTenant || t.TenantId == TenantId).Where(predicate).AsNoTracking();
            }
            else
            {
                list = _dbContext.Set<T>().Where(t => !withTenant || t.TenantId == TenantId).AsNoTracking();
            }
        }

        return list;
    }

    public virtual async Task<T> GetByIdAsync(Guid id, bool trackable = false) 
        => trackable ? await _dbContext.Set<T>()
            .Where(t => t.TenantId == TenantId && t.Id == id)
            .AsTracking()
            .FirstOrDefaultAsync() 
            ?? throw new Exception("Not able to return a entity for this Id") 
            : await _dbContext.Set<T>()
            .Where(t => t.TenantId == TenantId && t.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync() 
            ?? throw new Exception("Not able to return a entity for this Id");
    
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