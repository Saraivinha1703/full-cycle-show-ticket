using Caticket.SalesAPI.Domain.Entities;
using Caticket.SalesAPI.Domain.Enumerators;

namespace Caticket.SalesAPI.Core.DTOs.Request;

public class PartnerReservationRequest {
    public Spot[] Spots { get; set; } = [];
    public required TicketType TicketType { get; set; }
    public required string Email { get; set; }
}