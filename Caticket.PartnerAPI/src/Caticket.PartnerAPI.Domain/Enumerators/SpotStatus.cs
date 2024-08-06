namespace Caticket.PartnerAPI.Domain.Enumerators;

public class SpotStatus : Enumeration {
    private SpotStatus(string name, int id) : base(name, id) {}
    
    public static SpotStatus Available { get; private set; } = new("available", 0);
    public static SpotStatus Reserved { get; private set; } = new("reserved", 1);

    public static void DefaultIfNull(ref SpotStatus @this) 
        => @this ??= Available;
}