namespace Caticket.PartnerAPI.Domain.Interfaces;

public interface IBaseEntity
{
    public Guid Id {get;}
    public Guid TenantId {get;}
}