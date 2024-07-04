namespace Caticket.SalesAPI.Domain.Enumerators;

public class TicketType : Enumeration {
    private TicketType(string name, int id) : base(name, id) {}
    
    public static TicketType Full { get; private set; } = new("full", 0);
    public static TicketType Half { get; private set; } = new("half", 1);

}