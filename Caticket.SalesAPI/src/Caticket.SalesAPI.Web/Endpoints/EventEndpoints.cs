using Microsoft.AspNetCore.Mvc;
using Caticket.SalesAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Caticket.SalesAPI.Web.Services;

namespace Caticket.SalesAPI.Web.Endpoints;

public static class EventEndpoints {
    public static void MapEventsEndpoints(this WebApplication app) {
        app.MapGet(
            "/event/{eventId}", 
            [Authorize]
            (
                Guid eventId, 
                [FromServices] EventService eventService
            ) => "aaa"
        );
        
        app.MapGet(
            "/all-events", 
            [Authorize]
            async (
                [FromServices] EventService eventService
            ) => {
                await eventService.ListAllEvents();
            }
        );
    }
}