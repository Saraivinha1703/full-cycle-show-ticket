namespace Caticket.PartnerAPI.Core.Interfaces;

public interface IRepository<T> : IDisposable where T : class {
    Task CreateAsync();
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
    Task<int> SaveAsync();
}