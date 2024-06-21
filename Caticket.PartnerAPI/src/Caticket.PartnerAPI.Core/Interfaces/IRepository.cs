namespace Caticket.PartnerAPI.Core.Interfaces;

public interface IRepository<T> : IDisposable where T : class, IBase {
    Task CreateAsync(T entity);
    Task<IQueryable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
    Task<int> SaveAsync();
}