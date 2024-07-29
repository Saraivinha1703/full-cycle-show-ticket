using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.DTOs.Response;

public class PartnerReservationResponse {
    public required string[] Item1 { get; set; }
    public List<PartnerTicket>? Item2 { get; set; }
}

public class PartnerTicket {
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required int TicketKind { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required Guid SpotId { get; set; }
    public required PartnerSpot Spot {get; set;}
}

public class PartnerSpot {
    public required string Name { get; set; }
    public required int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required Guid EventId { get; set; }
}