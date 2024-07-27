using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.DTOs.Response;

public class PartnerReservationResponse {
    public required Guid Id { get; set; }
    public required string Email { get; set; }
    public required Spot Spot { get; set; }
    public required TicketType TicketKind { get; set; }
    public required SpotStatus Status { get; set; }
    public Guid EventId { get; set; }
}