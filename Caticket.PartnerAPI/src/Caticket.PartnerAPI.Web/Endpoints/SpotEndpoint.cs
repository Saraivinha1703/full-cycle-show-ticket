using Microsoft.AspNetCore.Mvc;
using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Web.DTO.Spot;

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
                [FromBody] CreateSpotDto createSpotDto, 
                [FromServices] SpotService spotService
            ) => {
                return await spotService.CreateSpot(eventId, createSpotDto);
            }
        );
    }
}