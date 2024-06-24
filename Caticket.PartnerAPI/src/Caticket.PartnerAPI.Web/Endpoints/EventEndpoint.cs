using Caticket.PartnerAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Caticket.PartnerAPI.Web.Endpoints;

public record Dto(string Name);
public static class EventEndpoint {
    public static void MapEventEndpoints(this WebApplication app) {
        app.MapGet("/event", () => "Hello from Events");
        
        app.MapPost(
            "/event", 
            async ([FromServices] EventService _eventService) => {
                await _eventService.CreateEvent("a");
                return "event created!";
            }
        );

        app.MapPost(
            "/event-name", 
            async ([FromBody] Dto dto, [FromServices] EventService _eventService) => {
                Console.WriteLine("Name: " + dto.Name);
                return await _eventService.GetEventByName(dto.Name);
            }
        );
    }
}