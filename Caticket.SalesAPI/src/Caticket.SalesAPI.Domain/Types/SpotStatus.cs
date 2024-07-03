namespace Caticket.SalesAPI.Domain.Types;

// public abstract record SpotStatus(string Status);

// public record SpotAvailable() : SpotStatus("available");

// public record SpotReserved(): SpotStatus("reserved");

public class SpotStatus {
    private SpotStatus(string status) {
        Status = status;
    }
    
    public string Status { get; private set; } = null!;

    public static SpotStatus Available { get; private set; } = new("available");
    public static SpotStatus Reserved { get; private set; } = new("reserved");
}