using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.DTOs.Request;

public class ReservationRequest {
    public required Guid EventId { get; set; }
    public required string Email { get; set; }
    public ReservationSpotRequest[] Spots { get; set; } = [];
    public required string CardHash { get; set; }
}

public class ReservationSpotRequest {
    public required string Name { get; set; }
    public required int TicketType { get; set; }
}