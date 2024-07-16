using Microsoft.AspNetCore.Mvc;
using Caticket.SalesAPI.Application.DTOs.Request;
using Caticket.SalesAPI.Application.Interfaces.Services;
using Caticket.SalesAPI.Application.DTOs.Response;

namespace Caticket.SalesAPI.Web.Endpoints.Authentication;

public static class UserEndpoints {
    public static void MapUserEndpoints(this WebApplication app) {
        app.MapPost(
            "/register/partner", 
            async (
                [FromBody] UserSignUpRequest userDto, 
                [FromServices] IIdentityService identityService
            ) => {
                var result = await identityService.SignUpAsync(userDto);

                if(!result.Success)
                    return Results.BadRequest(result);

                return Results.Ok(result);
            }
        );
        app.MapPost("/register/user", () => {return "common user";});
        app.MapPost("/login", () => {return "login";});
    }
}