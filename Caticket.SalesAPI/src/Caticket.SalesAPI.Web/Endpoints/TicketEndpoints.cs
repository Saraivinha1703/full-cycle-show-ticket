using Microsoft.AspNetCore.Mvc;
using Caticket.SalesAPI.Core.Services;
using Caticket.SalesAPI.Web.DTOs.Request;
using Caticket.SalesAPI.Core.DTOs.Request;
using Caticket.SalesAPI.Domain.Enumerators;
using Caticket.SalesAPI.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Caticket.SalesAPI.Web.Endpoints;

public static class TicketEndpoints {
    public static void MapTicketEndpoints(this WebApplication app) {
        app.MapPost(
            "/ticket/buy", 
            async (
                [FromServices] TicketService ticketService, 
                [FromServices] PartnerService partnerService,
                [FromServices] SpotService spotService,
                [FromBody] BuyTicketsRequest ticketsRequest
            ) => {
                await partnerService.MakeReservation(new() {
                    EventId = ticketsRequest.EventId,
                    Email = ticketsRequest.Email,
                    CardHash = ticketsRequest.CardHash,
                    Spots = ticketsRequest.Spots
                        .AsEnumerable()
                        .Select(
                            s => new ReservationSpotRequest() { 
                                Name = s.Name, 
                                TicketType = Enumeration.From<TicketType>(s.TicketType).Id 
                            }
                        ).ToArray(),
                });

                IEnumerable<Ticket> tickets = ticketsRequest.Spots
                    .AsEnumerable()
                    .Select(s => GenerateTicket(s, ticketService, spotService, ticketsRequest.EventId).Result);
                
                await ticketService.CreateTickets(tickets.ToList());

                _ = tickets.Select(t => spotService.ReserveSpot(t.Spot.Id, t.Id));
            }
        );
    }

    private static async Task<Ticket> GenerateTicket(SpotRequest s, TicketService ticketService, SpotService spotService, Guid eventId) {
        Ticket ticket = new(
            Enumeration.From<TicketType>(s.TicketType), 
            s.Owner, 
            s.OwnerLegalIdentification,
            await ticketService.CalculatePrice(eventId, Enumeration.From<TicketType>(s.TicketType)),
            eventId,
            await spotService.FindSpotByName(eventId, s.Name)
        );
        
        return ticket;
    }
}