namespace Caticket.SalesAPI.Web.DTOs.Response;

public class BuyTicketsResponse {
    public Guid EventId { get; set; }
    
    public Guid TicketId { get; set;}

    public required string TicketOwner { get; set; }

    public required string OwnerLegalIdentification { get; set; }

    public required string EventName { get; set; }
    
    public required string Spot { get; set; }
    
    public required string CardHash { get; set; }
    
    public required string Email { get; set; }
}