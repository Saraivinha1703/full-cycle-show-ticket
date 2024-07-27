using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.DTOs.Response;

public class ReservationResponse { 
    public Guid Id { get; set; }
    public Guid? EventId { get; set; }
    public string? Email { get; set; }
    public required Spot Spot { get; set; }
    public TicketType? TicketType { get; set; }
    public required SpotStatus Status { get; set; }
}