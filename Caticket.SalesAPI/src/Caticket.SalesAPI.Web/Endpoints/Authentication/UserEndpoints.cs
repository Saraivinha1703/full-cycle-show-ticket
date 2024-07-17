using Microsoft.AspNetCore.Mvc;
using Caticket.SalesAPI.Application.DTOs.Request;
using Caticket.SalesAPI.Application.Interfaces.Services;
using Caticket.SalesAPI.Application.DTOs.Response;
using Caticket.SalesAPI.Web.Filters;
using Microsoft.AspNetCore.Authorization;

namespace Caticket.SalesAPI.Web.Endpoints.Authentication;

public static class UserEndpoints {
    public static void MapUserEndpoints(this WebApplication app) {
        app.MapPost(
            "/register/partner", 
            async (
                [FromBody] UserSignUpRequest userDto, 
                [FromServices] IIdentityService identityService
            ) => {
                UserSignUpResponse result = await identityService.SignUpAsync(userDto);

                if(!result.Success)
                    return Results.BadRequest(result);

                return Results.Ok(result);
            }
        ).AddEndpointFilter<ValidationFilter<UserSignUpRequest>>();
        
        app.MapGet(
            "/test", 
            [Authorize] 
            () => {
                return "test";
            }
        );

        app.MapPost(
            "/login", 
            async (
                [FromBody] UserLoginRequest userDto, 
                [FromServices] IIdentityService identityService
            ) => {
                UserLoginResponse result = await identityService.LoginAsync(userDto);

                if(!result.Success)
                    return Results.BadRequest(result);

                return Results.Ok(result);
            }
        ).AddEndpointFilter<ValidationFilter<UserLoginRequest>>();
    }
}