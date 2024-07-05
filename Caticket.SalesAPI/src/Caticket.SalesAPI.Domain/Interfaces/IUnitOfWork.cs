namespace Caticket.SalesAPI.Domain.Interfaces;

public interface IUnitOfWork {
    Task<bool> Commit();

    Task Rollback();
}