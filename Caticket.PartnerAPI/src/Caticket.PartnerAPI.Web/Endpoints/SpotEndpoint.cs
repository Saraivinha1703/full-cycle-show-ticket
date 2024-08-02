using Microsoft.AspNetCore.Mvc;
using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Core.DTO.Event;
using Caticket.PartnerAPI.Web.DTO.Spot;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enums;

namespace Caticket.PartnerAPI.Web.Endpoints;

public static class SpotEndpoint {
    public static void MapSpotEndpoints(this WebApplication app) {
        //spots on events just for specific tenant
        app.MapGet(
            "/events/{eventId}/spots", 
            async (
                Guid eventId, 
                [FromServices] SpotService spotService, 
                [FromServices] EventService eventService
            ) => {
                return new { 
                    Event = await eventService.GetEventById(eventId), 
                    Spots = await spotService.GetAllSpots(eventId) 
                };
            }
        );

        app.MapPost("/events/{eventId}/spots", 
            async (
                Guid eventId, 
                [FromBody] CreateSpotRequest createSpotDto, 
                [FromServices] SpotService spotService,
                [FromServices] EventService eventService,
                [FromServices] TenantProvider tenantProvider
            ) => {
                Guid tenantId = tenantProvider.GetTenantId() ?? throw new ApplicationException($"POST /events/{eventId}/spots can not be executed without a tenant Id.");

                Spot spot = new() {
                    EventId = eventId, 
                    Name = createSpotDto.Name, 
                    TenantId = tenantId,
                    CreatedAt = DateTime.Now, 
                    Status = SpotStatus.Available
                };

                return await spotService.CreateSpot(eventId, spot);
            }
        );
        
        app.MapPost("/events/{eventId}/spots/reserve", 
           async (
                Guid eventId, 
                [FromBody] ReserveSpotDto reserveSpotDto, 
                [FromServices] EventService eventService,
                [FromServices] TenantProvider tenantProvider
            ) => {
                Guid tenantId = tenantProvider.GetTenantId() ?? throw new ApplicationException($"POST /events/{eventId}/spots/reserve can not be executed without a tenant Id.");
            
                return await eventService.ReserveSpot(reserveSpotDto, eventId, tenantId);
            }
        );
    }
}