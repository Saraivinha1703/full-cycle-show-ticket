namespace Caticket.PartnerAPI.Web.Endpoints;

public static class SpotEndpoint {
    public static void MapSpotEndpoints(this WebApplication app) {
        app.MapGet("/spot", () => "Hello from Spot");
    }
}