using Microsoft.AspNetCore.Mvc;
using Caticket.SalesAPI.Core.Services;

namespace Caticket.SalesAPI.Web.Endpoints;

public static class EventEndpoints {
    public static void MapEventsEndpoints(this WebApplication app) {
        app.MapGet(
            "/event/{eventId}", 
            async (
                Guid eventId, 
                [FromServices] EventService eventService
            ) => await eventService.GetEvent(eventId)
        );
        
        app.MapGet(
            "/events", 
            async (
                [FromServices] EventService eventService
            ) => await eventService.ListEvents()
        );
    }
}