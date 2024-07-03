namespace Caticket.SalesAPI.Domain.Types;

public class TicketType {
    private TicketType(string type) {
        Type = type;
    }

    public string Type { get; private set; } = null!;

    public static TicketType Full { get; private set; } = new("full");
    public static TicketType Half { get; private set; } = new("half");

}