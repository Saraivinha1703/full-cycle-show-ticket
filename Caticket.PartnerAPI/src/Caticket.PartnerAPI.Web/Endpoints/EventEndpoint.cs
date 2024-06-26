using System.Reflection;
using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Web.DTO;
using Caticket.PartnerAPI.Web.DTO.Event;
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
            async ([FromBody] CreateEventRequest eventDto, [FromServices] EventService eventService) => {
                Event e = new() {
                    Name = eventDto.Name, 
                    Description = eventDto.Description,    
                    Date = DateTime.Parse(eventDto.Date),
                    Price = eventDto.Price,
                };

                var eventResponse = await eventService.CreateEvent(e);

                CreateEventResponse createEventResponse = new(
                    eventResponse.Id,
                    eventResponse.Name,
                    eventResponse.Description,
                    eventResponse.Date.ToString(),
                    eventResponse.CreatedAt.ToString(),
                    eventResponse.Price
                );

                return createEventResponse;
            }
        );

        app.MapPatch(
            "/events", 
            async ([FromBody] UpdateEventRequest updateEventDto, [FromServices] EventService eventService) => {
                Event e = new() {
                    Id = updateEventDto.Id,
                    Name = updateEventDto.Name, 
                    Description = updateEventDto.Description,    
                    Date = DateTime.Parse(updateEventDto.Date),
                    Price = updateEventDto.Price,
                };

                var updateResponse = await eventService.Update(e);

                UpdateEventResponse updateEventResponse = new(
                    updateResponse.Id, 
                    updateResponse.Name, 
                    updateResponse.Description, 
                    updateResponse.Date.ToString(),
                    updateResponse.Price
                ); 

                return updateEventResponse;
            }
        );

        app.MapDelete(
            "/events", 
            async ([FromBody] BaseDeleteRequest deleteDto, [FromServices] EventService eventService) => {
                await eventService.Delete(deleteDto.Id);
                return "event deleted!";
            });
    }
}