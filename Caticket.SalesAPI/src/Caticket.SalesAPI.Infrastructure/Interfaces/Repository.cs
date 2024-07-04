
// using System.Linq.Expressions;
// using Caticket.SalesAPI.Domain.Interfaces;
// using Caticket.SalesAPI.Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;

// namespace Caticket.SalesAPI.Infrastructure.Interfaces;

// public abstract class Repository<T>(DatabaseContext dbContext) : IRepository<T> where T : class, IBaseEntity
// {
//     private readonly DatabaseContext _dbContext = dbContext;

//     public virtual async Task CreateAsync(T entity)
//     {
//         await _dbContext.Set<T>().AddAsync(entity);
//     }
    
//     public virtual async Task CreateRangeAsync(List<T> entities)
//     {
//         await _dbContext.Set<T>().AddRangeAsync(entities);
//     }

//     public virtual async Task DeleteAsync(Guid id)
//     {
//         T entity = await GetByIdAsync(id);

//         _dbContext.Set<T>().Remove(entity);
//     }

//     public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, bool? queryable = false, bool? trackable = false)
//     {
//         IEnumerable<T> list = [];
//         if(queryable == true && trackable == false) {
//             if(predicate != null) {
//                 list = [.. _dbContext.Set<T>().Where(predicate).AsNoTracking().AsQueryable()];
//             } else {
//                 list = [.. _dbContext.Set<T>().AsNoTracking().AsQueryable()];
//             }
//         } 
//         else if(trackable == true && queryable == false) {
//             if(predicate != null) {
//                 list = [.. _dbContext.Set<T>().Where(predicate).AsTracking()];
//             } else {
//                 list = _dbContext.Set<T>().AsEnumerable().ToList();
//             }
//         } 
//         else if (trackable == true && queryable == true) {
//             if(predicate != null) {
//                 list = [.. _dbContext.Set<T>().Where(predicate).AsTracking().AsQueryable()];
//             } else {
//                 list = [.. _dbContext.Set<T>().AsTracking().AsQueryable()];
//             }
//         } else {
//             if (predicate != null) {
//                 list = await _dbContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
//             } else {
//                 list = await _dbContext.Set<T>().AsNoTracking().ToListAsync();
//             }
//         }

//         return list;
//     }

//     public virtual async Task<T> GetByIdAsync(Guid id, bool trackable = false) =>
//          trackable ? await _dbContext.Set<T>()
//             .Where(t => t.Id == id)
//             .AsTracking()
//             .FirstOrDefaultAsync() 
//             ?? throw new Exception("Not able to return a entity for this Id") 
//             : await _dbContext.Set<T>()
//             .Where(t => t.Id == id)
//             .AsNoTracking()
//             .FirstOrDefaultAsync() 
//             ?? throw new Exception("Not able to return a entity for this Id");

//     // public virtual void Update(T entity)
//     // {
//     //     _dbContext.Set<T>().Update(entity);
//     // }
    
//     // public virtual void UpdateRange(List<T> entities)
//     // {
//     //     _dbContext.Set<T>().UpdateRange(entities);
//     // }

    
//     private bool disposed = false;
//     protected virtual void Dispose(bool disposing)
//     {
//         if (!disposed)
//         {
//             if (disposing)
//             {
//                 _dbContext.Dispose();
//             }
//         }
//         disposed = true;
//     }

//     public virtual void Dispose()
//     {
//         Dispose(true);
//         GC.SuppressFinalize(this);
//     }
// }