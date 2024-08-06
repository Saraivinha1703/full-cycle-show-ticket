using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enumerators;
using Caticket.PartnerAPI.Web.DTO;
using Caticket.PartnerAPI.Web.DTO.Event;
using Microsoft.AspNetCore.Mvc;

namespace Caticket.PartnerAPI.Web.Endpoints;

public static class EventEndpoint {
    public static void MapEventEndpoints(this WebApplication app) {
        app.MapGet(
            "/all-events", 
            ([FromServices] EventService eventService) => {
               return eventService.GetAllEvents();
            }
        );

        app.MapGet(
            "/events", 
            ([FromServices] EventService eventService) => {
               return eventService.GetAllTenantEvents();
            }
        );
        
        app.MapPost(
            "/events", 
            async (
                [FromBody] CreateEventRequest eventDto, 
                [FromServices] EventService eventService,
                [FromServices] TenantProvider tenantProvider
            ) => {
                Guid tenantId = tenantProvider.GetTenantId() ?? throw new ApplicationException("POST /events can not be executed without a Tenant Id.");

                Event e = new(
                    name: eventDto.Name, 
                    location: eventDto.Location, 
                    organization: eventDto.Organization,
                    imageURL: eventDto.ImageURL,
                    capacity: eventDto.Capacity, 
                    price: eventDto.Price, 
                    date: DateTime.Parse(eventDto.Date), 
                    createdAt: DateTime.Now, 
                    description: eventDto.Description, 
                    rating: eventDto.Rating != null ? Enumeration.From<Rating>(eventDto.Rating) : null
                    ) {
                        TenantId = tenantId
                    };

                var eventResponse = await eventService.CreateEvent(e);

                CreateEventResponse createEventResponse = new(
                    Id: eventResponse.Id,
                    Name: eventResponse.Name,
                    Location: eventResponse.Location,
                    Organization: eventResponse.Organization,
                    ImageURL: eventResponse.ImageURL,
                    Capacity: eventResponse.Capacity,
                    Price: eventResponse.Price,
                    Date: eventResponse.Date.ToString(),
                    CreatedAt: eventResponse.CreatedAt.ToString(),
                    TenantId: eventResponse.TenantId,
                    Description: eventResponse.Description,
                    Rating: eventResponse.Rating.Name
                );

                return createEventResponse;
            }
        );

        app.MapPatch(
            "/events", 
            async (
                [FromBody] UpdateEventRequest updateEventDto, 
                [FromServices] EventService eventService,
                [FromServices] TenantProvider tenantProvider
            ) => {
                Guid tenantId = tenantProvider.GetTenantId() ?? throw new ApplicationException("PATCH /events can not be executed without a Tenant Id.");

                Event e = new(
                    name: updateEventDto.Name, 
                    location: updateEventDto.Location, 
                    organization: updateEventDto.Organization,
                    imageURL: updateEventDto.ImageURL,
                    capacity: updateEventDto.Capacity, 
                    price: updateEventDto.Price, 
                    date: DateTime.Parse(updateEventDto.Date), 
                    createdAt: DateTime.Now, 
                    description: updateEventDto.Description, 
                    rating: updateEventDto.Rating != null ? Enumeration.From<Rating>(updateEventDto.Rating) : null
                    ) {
                        Id = updateEventDto.Id,
                        TenantId = tenantId
                    };

                var updateResponse = await eventService.Update(e);

                UpdateEventResponse updateEventResponse = new(
                    Id: updateResponse.Id,
                    Name: updateResponse.Name,
                    Location: updateResponse.Location,
                    Organization: updateResponse.Organization,
                    ImageURL: updateResponse.ImageURL,
                    Capacity: updateResponse.Capacity,
                    Price: updateResponse.Price,
                    Date: updateResponse.Date.ToString(),
                    CreatedAt: updateResponse.CreatedAt.ToString(),
                    TenantId: updateResponse.TenantId,
                    Description: updateResponse.Description,
                    Rating: updateResponse.Rating.Name
                ); 

                return updateEventResponse;
            }
        );

        app.MapDelete(
            "/events", 
            async (
                [FromBody] BaseDeleteRequest deleteDto, 
                [FromServices] EventService eventService
            ) => {
                await eventService.Delete(deleteDto.Id);
                return "event deleted!";
            });
    }
}