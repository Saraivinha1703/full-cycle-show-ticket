using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Domain.Entities;
using FakeItEasy;
using Shouldly;

namespace Caticket.PartnerAPI.Tests;

public class SpotServiceTests {
    private readonly SpotService spotService;

    public SpotServiceTests() {
        spotService = A.Fake<SpotService>();
    }

    // [Fact]
    // public async Task SpotService_CreateSpot_ExpectSpot() {
    //     var eventId = Guid.NewGuid();

    //     var spot = new Spot() {
    //         EventId = eventId,
    //         Name = "A1",
    //         CreatedAt = DateTime.Now,
    //         Status = SpotStatus.Available,
    //     };

    //     var result = await spotService.CreateSpot(eventId, spot);

    //     result.ShouldBe(spot);
    // }
}