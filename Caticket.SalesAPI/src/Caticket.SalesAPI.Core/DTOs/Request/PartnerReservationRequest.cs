namespace Caticket.SalesAPI.Core.DTOs.Request;

public class PartnerReservationRequest {
    public string[] Spots { get; set; } = [];
    public required int TicketKind { get; set; }
    public required string Email { get; set; }
}