using Caticket.SalesAPI.Core.Services;
using Caticket.SalesAPI.Domain.Enumerators;
using Caticket.SalesAPI.Domain.Exceptions;
using Shouldly;

namespace Caticket.SalesAPI.Tests;

public class TicketServiceTests {

    [Fact]
    public void TicketType_IsValid_Boolean() {
        var err = Enumeration.IsValid<TicketType>("x");
        var err2 = Enumeration.IsValid<TicketType>("haLf");

        var ok = Enumeration.IsValid<TicketType>("half");
        var ok2 = Enumeration.IsValid<TicketType>("full");

        err.ShouldBe(false);
        err2.ShouldBe(false);
        ok.ShouldBe(true);
        ok2.ShouldBe(true);
    }

    // [Fact]
    //  public void TicketService_TicketTest() {
    //     var ticketService = new TicketService();

    //     TicketType half = ticketService.TestTicketType("half");
    //     TicketType full = ticketService.TestTicketType("full");
    //     var ex = Should.Throw<InvalidEnumerationException>(() => ticketService.TestTicketType("fuLl"));

    //     half.ShouldBe(TicketType.Half);
    //     full.ShouldBe(TicketType.Full);
    //     ex.ShouldNotBeNull().ShouldBeOfType<InvalidEnumerationException>();
    // }
}