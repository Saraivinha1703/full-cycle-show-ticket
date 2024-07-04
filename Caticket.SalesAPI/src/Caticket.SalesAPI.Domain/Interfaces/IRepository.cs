using System.Linq.Expressions;
using Caticket.SalesAPI.Domain.Interfaces;

namespace Caticket.PartnerAPI.Domain.Interfaces;

public interface IRepository<T> : IDisposable where T : IBaseEntity {
    Task CreateAsync(T entity);
    Task CreateRangeAsync(List<T> entities);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, bool? queryable = false, bool? trackable = false);
    Task<T> GetByIdAsync(Guid id, bool trackable = false);
    Task DeleteAsync(Guid id);
}