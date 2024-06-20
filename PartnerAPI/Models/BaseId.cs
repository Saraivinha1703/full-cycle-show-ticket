namespace PartnerAPI.Models;

public class BaseId {
    public Guid Id { get; private set; } = Guid.NewGuid(); 
}