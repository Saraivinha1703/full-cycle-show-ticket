namespace Caticket.SalesAPI.Web.Endpoints.Authentication;

public static class UserEndpoints {
    public static void MapUserEndpoints(this WebApplication app) {
        app.MapPost("/register/partner", () => {return "partner user";});
        app.MapPost("/register/user", () => {return "common user";});
        app.MapPost("/login", () => {return "login";});
    }
}