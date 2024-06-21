using Caticket.PartnerAPI.Core.Interfaces;

namespace Caticket.PartnerAPI.Core.Entities;

public class BaseId : IBaseId {
    public Guid Id { get; private set; } = Guid.NewGuid(); 
}