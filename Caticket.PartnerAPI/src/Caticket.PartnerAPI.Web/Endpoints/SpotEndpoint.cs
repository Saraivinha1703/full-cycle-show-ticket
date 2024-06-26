using Microsoft.AspNetCore.Mvc;
using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Web.DTO.Spot;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enums;

namespace Caticket.PartnerAPI.Web.Endpoints;

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
    }
}