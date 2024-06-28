namespace Caticket.PartnerAPI.Domain.Interfaces;

public interface IUnitOfWork {
    Task<bool> Commit();

    Task Rollback();
}