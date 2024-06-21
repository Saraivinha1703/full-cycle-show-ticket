namespace Caticket.PartnerAPI.Web.Endpoints;

public static class EventEndpoint {
    public static void MapEventEndpoints(this WebApplication app) {
        app.MapGet("/event", () => "Hello from Events");
    }
}