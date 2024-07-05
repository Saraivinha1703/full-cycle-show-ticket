using Microsoft.AspNetCore.Mvc;
using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Core.DTO.Event;
using Caticket.PartnerAPI.Web2.DTO.Spot;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enums;

namespace Caticket.PartnerAPI.Web2.Endpoints;

public static class SpotEndpoint {
    public static void MapSpotEndpoints(this WebApplication app) {
        app.MapGet(
            "/events/{eventId}/spots", 
            async (Guid eventId, [FromServices] SpotService spotService) => {
                return await spotService.GetAllSpots(eventId);
            }
        );

        app.MapPost("/events/{eventId}/spots", 
            async (
                Guid eventId, 
                [FromBody] CreateSpotRequest createSpotDto, 
                [FromServices] SpotService spotService,
                [FromServices] EventService eventService
            ) => {
                Spot spot = new() {
                    EventId = eventId, 
                    Name = createSpotDto.Name, 
                    CreatedAt = DateTime.Now, 
                    Status = SpotStatus.Available
                };

                return await spotService.CreateSpot(eventId, spot);
            }
        );
        
        app.MapPost("/events/{eventId}/spots/reserve", 
           async (Guid eventId, [FromBody] ReserveSpotDto reserveSpotDto, [FromServices] EventService eventService) => {
            return await eventService.ReserveSpot(reserveSpotDto, eventId);
        });
    }
}