using Microsoft.AspNetCore.Mvc;
using Caticket.SalesAPI.Core.Services;

namespace Caticket.SalesAPI.Web.Endpoints;

public static class SpotEndpoints {
    public static void MapSpotEndpoints(this WebApplication app) {
        app.MapGet(
            "/events/{eventId}/spots", 
            (Guid eventId, [FromServices] SpotService spotService) 
                => spotService.GetAllSpots(eventId)
        );
    }
}