using System.Linq.Expressions;

namespace Caticket.PartnerAPI.Domain.Interfaces;

public interface IRepository<T> : IDisposable where T : IBaseEntity {
    Task CreateAsync(T entity);
    Task CreateRangeAsync(List<T> entities);
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, bool queryable = false, bool trackable = false, bool withTenant = false);
    Task<T> GetByIdAsync(Guid id, bool trackable = false);
    Task DeleteAsync(Guid id);
}