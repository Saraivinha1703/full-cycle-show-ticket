using Caticket.SalesAPI.Domain.Interfaces;

namespace Caticket.SalesAPI.Domain.Entities;

public abstract class BaseEntity : IBaseEntity {
    public Guid Id { get; set; } = Guid.NewGuid();
}