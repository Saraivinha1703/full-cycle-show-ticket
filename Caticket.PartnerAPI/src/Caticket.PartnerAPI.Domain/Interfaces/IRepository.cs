using System.Linq.Expressions;

namespace Caticket.PartnerAPI.Domain.Interfaces;

public interface IRepository<T> : IDisposable where T : IBaseEntity {
    Task CreateAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, bool? queryable = false, bool? trackable = false);
    Task<T> GetByIdAsync(Guid id);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<int> SaveAsync();
}