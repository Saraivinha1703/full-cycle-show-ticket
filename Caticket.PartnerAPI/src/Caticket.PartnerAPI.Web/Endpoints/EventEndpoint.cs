using System.Reflection;
using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Web.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Caticket.PartnerAPI.Web.Endpoints;

public class Dto {
    public string? Name { get; set; }

    public static ValueTask<Dto?> BindAsync(HttpContext context, ParameterInfo parameter) {
        string? name = context.Request.Query["Name"];

        return ValueTask.FromResult<Dto?>(new() { Name = name });
    }
};

public static class EventEndpoint {
    public static void MapEventEndpoints(this WebApplication app) {
        app.MapGet(
            "/events", 
            async (Dto dto, [FromServices] EventService eventService) => {
                if(dto.Name == null) return await eventService.GetAllEvents();
            
                return await eventService.GetEventByName(dto.Name);
            }
        );
        
        app.MapPost(
            "/events", 
            async ([FromBody] CreateEventDto eventDto, [FromServices] EventService eventService) => {
                return await eventService.CreateEvent(eventDto);
            }
        );

        app.MapPatch(
            "/events", 
            async ([FromBody] UpdateEventDto updateEventDto, [FromServices] EventService eventService) => {
                await eventService.Update(updateEventDto);
                return "event updated!";
            }
        );

        app.MapDelete(
            "/events", 
            async ([FromBody] BaseDeleteDto deleteDto, [FromServices] EventService eventService) => {
                await eventService.Delete(deleteDto.Id);
                return "event deleted!";
            });
    }
}