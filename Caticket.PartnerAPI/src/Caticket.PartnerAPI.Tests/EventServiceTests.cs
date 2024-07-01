using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Domain.Entities;
using Xunit;

namespace Caticket.PartnerAPI.Tests;

public class EventServiceTests(EventService eventService)
{
    private readonly EventService _eventService = eventService;

    [Fact]
    public async Task EventService_CreateEvent_EventObject()
    {
        //Arrange - Get the needed variables
        var ev = new Event() {
            Name = "Mamonas Assassinas Show",
            Description = "Mamonas Assassinas is the shit! Buy the ticket and come watch the show at Coco Beach!",
            CreatedAt = DateTime.Now,
            Date = new DateTime(2024, 11, 18),
            Price = 69.99m,
        };

        //Act - Execute the function that should be tested
        var result = await _eventService.CreateEvent(ev);

        //Assert - check if the result returned is the one expected
        Assert.Equal(ev, result);
    }
}