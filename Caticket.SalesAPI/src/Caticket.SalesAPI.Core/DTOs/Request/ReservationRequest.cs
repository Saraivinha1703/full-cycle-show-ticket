using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.DTOs.Request;

public class ReservationRequest {
    public required Guid EventId { get; set; }
    public required string Email { get; set; }
    public Spot[] Spots { get; set; } = [];
    public required TicketType TicketType { get; set; }    
    public required string CardHash { get; set; }
}