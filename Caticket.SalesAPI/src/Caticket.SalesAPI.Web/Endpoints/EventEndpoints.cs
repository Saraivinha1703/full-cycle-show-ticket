using Microsoft.AspNetCore.Mvc;
using Caticket.SalesAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Caticket.SalesAPI.Web.Services;
using Caticket.SalesAPI.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Caticket.SalesAPI.Identity.Constants;
using Caticket.SalesAPI.Core.DTOs.Partner;

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
            "/events", 
            [Authorize]
            async (
                [FromServices] EventService eventService,
                [FromServices] UserManager<User> userManager,
                [FromServices] UserProvider userProvider
            ) => {
                User user = await userProvider.GetUserAsync() ?? throw new ApplicationException("No user provided.");

                bool isPartner = await userManager.IsInRoleAsync(user, Roles.Partner);

                if(isPartner) {
                    return await eventService.ListEvents(Guid.Parse(user.Id));
                } else {
                    return await eventService.ListAllEvents();
                }
            }
        );

        app.MapPost(
            "/events", 
            [Authorize(Roles = Roles.Partner)]
            async (
                [FromServices] EventService eventService,
                [FromServices] UserProvider userProvider,
                [FromBody] CreateEventRequest createEventDto    
            ) => {
                Guid tenantId = userProvider.GetUserId() ?? throw new ApplicationException("POST /events can not execute with out a tenant id.");

                return await eventService.CreateEvent(tenantId, createEventDto);
            }
        );
    }
}