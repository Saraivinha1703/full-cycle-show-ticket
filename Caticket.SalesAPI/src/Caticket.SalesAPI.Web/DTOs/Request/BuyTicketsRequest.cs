namespace Caticket.SalesAPI.Web.DTOs.Request;

public class BuyTicketsRequest {
    public Guid EventId { get; set; }
    
    public required SpotRequest[] Spots { get; set; }

    public required string CardHash { get; set; }

    public required string Email { get; set; }
}

public class SpotRequest {
    public required string Name { get; set; }
     
    public required string Owner { get; set; }

    public required string OwnerLegalIdentification { get; set; }

    public required string TicketType { get; set; }
}