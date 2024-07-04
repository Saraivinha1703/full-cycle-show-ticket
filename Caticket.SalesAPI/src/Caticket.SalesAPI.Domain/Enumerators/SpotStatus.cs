namespace Caticket.SalesAPI.Domain.Enumerators;

// public abstract record SpotStatus(string Status);

// public record SpotAvailable() : SpotStatus("available");

// public record SpotReserved(): SpotStatus("reserved");

// public enum SpotStat {
//     Available = 0,
//     Reserved = 1,
// }

// public static class SpotStatEnumerators {
//     public static Dictionary<SpotStat, string> Names = new() { 
//         { SpotStat.Available, "available" },  
//         { SpotStat.Reserved, "reserved" }
//     };

//     public static SpotStat From(string value) 
//         => value switch {
//             var _ when value == Names[SpotStat.Available] => SpotStat.Available,
//             var _ when value == Names[SpotStat.Reserved] => SpotStat.Reserved,
//             var _ => throw new InvalidCastException($"Invalid string value: {value} for {nameof(SpotStat)}"),
//         };
// }

public class SpotStatus : Enumeration {
    private SpotStatus(string name, int id) : base(name, id) {}
    
    public static SpotStatus Available { get; private set; } = new("available", 0);
    public static SpotStatus Reserved { get; private set; } = new("reserved", 1);

    public static void DefaultIfNull(ref SpotStatus @this) 
        => @this ??= Available;
}