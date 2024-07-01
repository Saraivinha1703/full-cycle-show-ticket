using Caticket.PartnerAPI.Core.DTO.Event;
using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Domain.Entities;
using Caticket.PartnerAPI.Domain.Enums;
using Caticket.PartnerAPI.Domain.Interfaces;
using FakeItEasy;
using Shouldly;

namespace Caticket.PartnerAPI.Tests;

public class EventServiceTests
{
    private readonly EventService _eventService;

    public EventServiceTests() {
        var eventRepository = A.Fake<IEventRepository>();
        var spotRepository = A.Fake<ISpotRepository>();
        var ticketRepository = A.Fake<IRepository<Ticket>>();
        var reservationHistoryRepository = A.Fake<IRepository<ReservationHistory>>();
        var unitOfWork = A.Fake<IUnitOfWork>();
        _eventService = new EventService(eventRepository, spotRepository, ticketRepository, reservationHistoryRepository, unitOfWork);
    }

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
        result.ShouldBe(ev);
        result.UpdatedAt.ShouldBeNull();
    }

    [Fact]
    public async Task EventService_ReserveSpot_SpotsReserved() {
        var reserveSpotDto = new ReserveSpotDto(["A1",  "B2"], "some@email.com", TicketKind.Full);

        var result = await _eventService.ReserveSpot(reserveSpotDto, Guid.NewGuid());

        result.ShouldBeOfType<Tuple<List<string>, List<Ticket>?>>();
        result.Item1.ShouldAllBe(i => string.IsNullOrEmpty(i));
    }
}