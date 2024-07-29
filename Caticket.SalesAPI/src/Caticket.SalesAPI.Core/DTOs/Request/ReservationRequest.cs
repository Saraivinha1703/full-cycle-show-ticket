using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.DTOs.Request;

public class ReservationRequest {
    public required Guid EventId { get; set; }
    public required string Email { get; set; }
    public string[] Spots { get; set; } = [];
    public required int TicketType { get; set; }    
    public required string CardHash { get; set; }
}