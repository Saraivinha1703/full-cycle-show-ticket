using Caticket.PartnerAPI.Domain.Interfaces;

namespace Caticket.PartnerAPI.Domain.Entities;

public class BaseEntity : IBaseEntity {
    public Guid Id { get; set; } = Guid.NewGuid(); 

    public required Guid TenantId { get; set; } 
}