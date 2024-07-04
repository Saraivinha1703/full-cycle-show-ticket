using Caticket.SalesAPI.Core.Services;
using Caticket.SalesAPI.Domain.Entities;
using FakeItEasy;

namespace Caticket.SalesAPI.Tests;

public class SpotServiceTests {

    [Fact]
    public async Task SpotService_CreateSpots_SpotsList() {
        var spotService = A.Fake<SpotService>();
        
        IEnumerable<Spot> spots = await spotService.CreateSpotsRange(Guid.NewGuid(), 30, 8);
        
    }
}